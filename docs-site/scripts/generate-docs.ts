import fs from "node:fs";
import path from "node:path";
import matter from "gray-matter";
import MarkdownIt from "markdown-it";

type IconName =
  | "Rocket"
  | "MessageSquare"
  | "Settings"
  | "Shield"
  | "Layout"
  | "Building"
  | "Cpu"
  | "Search"
  | "Info"
  | "Globe";

interface SiteGroupConfig {
  id: string;
  title: string;
  icon: IconName;
  order?: number;
  homeLinks?: number;
  sources?: string[];
}

interface SiteConfig {
  brand: {
    name: string;
    github?: {
      href: string;
      title?: string;
      openInNewTab?: boolean;
    };
  };
  hero: {
    title: string;
    description: string;
  };
  repository?: {
    contentRoot?: string;
    defaultBranch?: string;
  };
  groups: SiteGroupConfig[];
}

interface DocHeading {
  id: string;
  text: string;
  level: number;
}

interface DocManifestEntry {
  slug: string;
  title: string;
  summary: string;
  description: string;
  groupId: string;
  order: number;
  tags: string[];
  excerpt: string;
  headings: DocHeading[];
  contentModule: string;
}

interface SearchEntry {
  id: string;
  kind: "doc" | "section";
  slug: string;
  sectionId?: string;
  title: string;
  description: string;
  keywords: string;
  scoreBoost: number;
}

interface ParsedDoc {
  filePath: string;
  rawContent: string;
  sourceKey: string;
  sourceOrder: number;
  slug: string;
  contentModule: string;
  title: string;
  summary: string;
  description: string;
  groupId: string;
  order: number;
  tags: string[];
  html: string;
  excerpt: string;
  headings: DocHeading[];
  sections: Array<{
    id: string;
    title: string;
    level: number;
    text: string;
  }>;
}

const rootDir = process.cwd();
const contentDir = path.join(rootDir, "content");
const configPath = path.join(contentDir, "site.config.json");
const generatedRootDir = path.join(rootDir, "src", "docs", "generated");
const generatedContentDir = path.join(generatedRootDir, "content");
const manifestPath = path.join(generatedRootDir, "manifest.ts");

function ensureDirectory(dirPath: string) {
  fs.mkdirSync(dirPath, { recursive: true });
}

function readJson<T>(filePath: string): T {
  return JSON.parse(
    fs.readFileSync(filePath, "utf8").replace(/^\uFEFF/, ""),
  ) as T;
}

function toPosix(filePath: string) {
  return filePath.replace(/\\/g, "/");
}

function slugify(value: string, counter = new Map<string, number>()) {
  const normalized =
    value
      .normalize("NFKD")
      .replace(/[\u0300-\u036f]/g, "")
      .toLowerCase()
      .replace(/[^a-z0-9\u4e00-\u9fa5]+/g, "-")
      .replace(/^-+|-+$/g, "") || "section";

  const currentCount = counter.get(normalized) ?? 0;
  counter.set(normalized, currentCount + 1);

  return currentCount === 0 ? normalized : `${normalized}-${currentCount}`;
}

function toDocSlugSegment(value: string) {
  return (
    value
      .normalize("NFKD")
      .replace(/[\u0300-\u036f]/g, "")
      .toLowerCase()
      .replace(/[^a-z0-9\u4e00-\u9fa5]+/g, "-")
      .replace(/^-+|-+$/g, "") || "doc"
  );
}

function stripMarkdown(value: string) {
  return value
    .replace(/```[\s\S]*?```/g, " ")
    .replace(/`([^`]+)`/g, "$1")
    .replace(/!\[[^\]]*\]\([^)]*\)/g, " ")
    .replace(/\[([^\]]+)\]\([^)]*\)/g, "$1")
    .replace(/<[^>]+>/g, " ")
    .replace(/^>\s?/gm, "")
    .replace(/^#+\s?/gm, "")
    .replace(/[>*_~|-]/g, " ")
    .replace(/\s+/g, " ")
    .trim();
}

function getMarkdownFiles(dirPath: string): string[] {
  if (!fs.existsSync(dirPath)) {
    return [];
  }

  return fs.readdirSync(dirPath, { withFileTypes: true }).flatMap((entry) => {
    const fullPath = path.join(dirPath, entry.name);

    if (entry.isDirectory()) {
      return getMarkdownFiles(fullPath);
    }

    if (
      entry.isFile() &&
      entry.name.endsWith(".md") &&
      !entry.name.startsWith("$")
    ) {
      return [fullPath];
    }

    return [] as string[];
  });
}

function createContentModuleName(slug: string) {
  return slug.replace(/[^a-z0-9/\u4e00-\u9fa5_-]+/gi, "-").replace(/\//g, "__");
}

function getSourceKey(filePath: string, repoRoot: string) {
  if (
    path.resolve(filePath) === path.resolve(path.join(repoRoot, "README.md"))
  ) {
    return "readme";
  }

  return path.basename(filePath, ".md").split(".")[0];
}

function getDocTitle(markdown: string, fallbackTitle: string) {
  const lines = markdown.split(/\r?\n/);
  const heading = lines.find((line) => /^#\s+/.test(line));
  return heading ? heading.replace(/^#\s+/, "").trim() : fallbackTitle;
}

function getDocSummary(markdown: string, fallback: string) {
  const text = stripMarkdown(markdown);
  if (!text) {
    return fallback;
  }

  return text.slice(0, 140);
}

function getSourcePaths(repoRoot: string) {
  const paths = [
    path.join(repoRoot, "README.md"),
    ...getMarkdownFiles(path.join(repoRoot, "UAPI", "docs")),
  ];
  return paths.filter((filePath) => fs.existsSync(filePath));
}

function getGroupForSource(siteConfig: SiteConfig, sourceKey: string) {
  return siteConfig.groups.find((group) => group.sources?.includes(sourceKey));
}

function buildRepositoryLinkBase(siteConfig: SiteConfig) {
  const repoUrl = siteConfig.brand.github?.href?.replace(/\/$/, "");
  const branch = siteConfig.repository?.defaultBranch ?? "master";

  if (!repoUrl || !repoUrl.includes("github.com/")) {
    return undefined;
  }

  return `${repoUrl}/blob/${branch}/`;
}

function resolveDocLink(
  href: string,
  currentFile: string,
  slugByFilePath: Map<string, string>,
  repoRoot: string,
  repositoryLinkBase?: string,
) {
  if (
    !href ||
    /^https?:\/\//i.test(href) ||
    href.startsWith("mailto:") ||
    href.startsWith("tel:")
  ) {
    return null;
  }

  if (href.startsWith("#")) {
    const sectionId = slugify(decodeURIComponent(href.slice(1)));
    return {
      type: "section" as const,
      sectionId,
    };
  }

  const [relativePath, fragment] = href.split("#");
  const resolvedPath = path.resolve(path.dirname(currentFile), relativePath);

  if (relativePath.endsWith(".md")) {
    const slug = slugByFilePath.get(resolvedPath);

    if (!slug) {
      return null;
    }

    return {
      type: "doc" as const,
      slug,
      sectionId: fragment ? slugify(decodeURIComponent(fragment)) : undefined,
    };
  }

  if (repositoryLinkBase && fs.existsSync(resolvedPath)) {
    const relativeFilePath = toPosix(path.relative(repoRoot, resolvedPath));
    return {
      type: "file" as const,
      href: `${repositoryLinkBase}${relativeFilePath}`,
    };
  }

  return null;
}

function buildMarkdownRenderer(
  currentFile: string,
  slugByFilePath: Map<string, string>,
  headings: DocHeading[],
  repoRoot: string,
  repositoryLinkBase?: string,
) {
  const markdown = new MarkdownIt({
    html: true,
    linkify: true,
    typographer: true,
  });

  const defaultHeadingOpen =
    markdown.renderer.rules.heading_open ??
    ((tokens, index, options, _env, self) =>
      self.renderToken(tokens, index, options));

  const defaultLinkOpen =
    markdown.renderer.rules.link_open ??
    ((tokens, index, options, _env, self) =>
      self.renderToken(tokens, index, options));

  const defaultImage =
    markdown.renderer.rules.image ??
    ((tokens, index, options, _env, self) =>
      self.renderToken(tokens, index, options));

  markdown.renderer.rules.heading_open = (
    tokens,
    index,
    options,
    env,
    self,
  ) => {
    const inlineToken = tokens[index + 1];
    const headingText = inlineToken?.content?.trim() ?? "";
    const level = Number(tokens[index].tag.slice(1));
    const slugCounter =
      (env as { slugCounter?: Map<string, number> }).slugCounter ??
      new Map<string, number>();

    (env as { slugCounter: Map<string, number> }).slugCounter = slugCounter;

    if (headingText) {
      const headingId = slugify(headingText, slugCounter);
      tokens[index].attrSet("id", headingId);

      if (level === 2 || level === 3) {
        headings.push({
          id: headingId,
          text: headingText,
          level,
        });
      }
    }

    return defaultHeadingOpen(tokens, index, options, env, self);
  };

  markdown.renderer.rules.link_open = (tokens, index, options, env, self) => {
    const href = tokens[index].attrGet("href") ?? "";
    const resolved = resolveDocLink(
      href,
      currentFile,
      slugByFilePath,
      repoRoot,
      repositoryLinkBase,
    );

    if (resolved?.type === "doc") {
      const params = new URLSearchParams();
      params.set("doc", resolved.slug);

      if (resolved.sectionId) {
        params.set("section", resolved.sectionId);
      }

      tokens[index].attrSet("href", `?${params.toString()}`);
      tokens[index].attrSet("data-doc-slug", resolved.slug);

      if (resolved.sectionId) {
        tokens[index].attrSet("data-doc-section", resolved.sectionId);
      }
    } else if (resolved?.type === "section") {
      tokens[index].attrSet("href", `#${resolved.sectionId}`);
    } else if (resolved?.type === "file") {
      tokens[index].attrSet("href", resolved.href);
      tokens[index].attrSet("target", "_blank");
      tokens[index].attrSet("rel", "noreferrer");
    } else if (/^https?:\/\//i.test(href)) {
      tokens[index].attrSet("target", "_blank");
      tokens[index].attrSet("rel", "noreferrer");
    }

    return defaultLinkOpen(tokens, index, options, env, self);
  };

  markdown.renderer.rules.image = (tokens, index, options, env, self) => {
    tokens[index].attrSet("loading", "lazy");
    tokens[index].attrSet("decoding", "async");
    tokens[index].attrSet("referrerpolicy", "no-referrer");
    return defaultImage(tokens, index, options, env, self);
  };

  return markdown;
}

function extractSections(markdown: string, docTitle: string) {
  const parser = new MarkdownIt({
    html: true,
    linkify: true,
    typographer: true,
  });
  const tokens = parser.parse(markdown, {});
  const counter = new Map<string, number>();
  const sections: Array<{
    id: string;
    title: string;
    level: number;
    text: string;
  }> = [];

  let currentSection = {
    id: "overview",
    title: docTitle,
    level: 1,
    text: "",
  };

  for (let index = 0; index < tokens.length; index += 1) {
    const token = tokens[index];

    if (token.type === "heading_open") {
      const level = Number(token.tag.slice(1));
      const inlineToken = tokens[index + 1];
      const headingText =
        inlineToken?.type === "inline" ? inlineToken.content.trim() : "";

      if (headingText) {
        currentSection = {
          id: slugify(headingText, counter),
          title: headingText,
          level,
          text: "",
        };

        if (level === 2 || level === 3) {
          sections.push(currentSection);
        }
      }

      continue;
    }

    if (token.type === "inline") {
      currentSection.text = `${currentSection.text} ${token.content}`.trim();
    }
  }

  return sections;
}

function writeTypeScriptModule(filePath: string, code: string) {
  ensureDirectory(path.dirname(filePath));
  fs.writeFileSync(filePath, code, "utf8");
}

function createManifestModule(manifest: {
  config: SiteConfig;
  groups: Array<
    SiteGroupConfig & { order: number; homeLinks: number; docs: string[] }
  >;
  docs: DocManifestEntry[];
  searchIndex: SearchEntry[];
  defaultDocSlug: string;
}) {
  return `import type {DocsManifest} from '../types';\n\nexport const docsManifest: DocsManifest = ${JSON.stringify(manifest, null, 2)};\n`;
}

function createContentModule(slug: string, html: string) {
  return `import type {DocContent} from '../../types';\n\nconst docContent: DocContent = ${JSON.stringify({ slug, html }, null, 2)};\n\nexport default docContent;\n`;
}

function main() {
  const siteConfig = readJson<SiteConfig>(configPath);
  const repoRoot = path.resolve(
    rootDir,
    siteConfig.repository?.contentRoot ?? "..",
  );
  const repositoryLinkBase = buildRepositoryLinkBase(siteConfig);
  const markdownFiles = getSourcePaths(repoRoot);
  const slugByFilePath = new Map<string, string>();

  for (const filePath of markdownFiles) {
    const sourceKey = getSourceKey(filePath, repoRoot);
    const configuredGroup = getGroupForSource(siteConfig, sourceKey);
    const groupId = configuredGroup?.id ?? toDocSlugSegment(sourceKey);
    const slugLeaf =
      sourceKey === "readme"
        ? "overview"
        : path.basename(filePath, ".md").replace(/\./g, "-");
    const slug = `${groupId}/${toDocSlugSegment(slugLeaf)}`;
    slugByFilePath.set(path.resolve(filePath), slug);
  }

  const configuredGroups = new Map<string, SiteGroupConfig>(
    siteConfig.groups.map((group) => [group.id, group]),
  );
  const groupsWithFallback = [...siteConfig.groups];

  const parsedDocs = markdownFiles.map<ParsedDoc>((filePath) => {
    const fileContent = fs.readFileSync(filePath, "utf8");
    const { data, content } = matter(fileContent);
    const sourceKey = getSourceKey(filePath, repoRoot);
    const configuredGroup = getGroupForSource(siteConfig, sourceKey);
    const groupId =
      typeof data.group === "string"
        ? data.group
        : (configuredGroup?.id ?? toDocSlugSegment(sourceKey));
    const sourceOrder =
      configuredGroup?.sources?.findIndex((item) => item === sourceKey) ?? 999;
    const slug =
      slugByFilePath.get(path.resolve(filePath)) ??
      `${groupId}/${toDocSlugSegment(path.basename(filePath, ".md"))}`;
    const contentModule = createContentModuleName(slug);
    const fallbackTitle =
      sourceKey === "readme"
        ? siteConfig.brand.name
        : path.basename(filePath, ".md");
    const title =
      typeof data.title === "string"
        ? data.title
        : getDocTitle(content, fallbackTitle);
    const summary =
      typeof data.summary === "string"
        ? data.summary
        : getDocSummary(content, title);
    const description =
      typeof data.description === "string" ? data.description : summary;
    const order =
      typeof data.order === "number"
        ? data.order
        : sourceKey === "readme"
          ? 0
          : 999;
    const tagsFromFrontmatter = Array.isArray(data.tags)
      ? data.tags.filter((tag): tag is string => typeof tag === "string")
      : [];
    const tags = Array.from(
      new Set([sourceKey, groupId, ...tagsFromFrontmatter]),
    );
    const headings: DocHeading[] = [];
    const markdown = buildMarkdownRenderer(
      filePath,
      slugByFilePath,
      headings,
      repoRoot,
      repositoryLinkBase,
    );
    const html = markdown.render(content, {
      slugCounter: new Map<string, number>(),
    });
    const plainText = stripMarkdown(content);
    const excerpt = plainText.slice(0, 160);
    const sections = extractSections(content, title);

    if (!configuredGroups.has(groupId)) {
      const fallbackGroup: SiteGroupConfig = {
        id: groupId,
        title: groupId,
        icon: "Info",
        order: 999,
        homeLinks: 4,
        sources: [sourceKey],
      };

      configuredGroups.set(groupId, fallbackGroup);
      groupsWithFallback.push(fallbackGroup);
    }

    return {
      filePath,
      rawContent: content,
      sourceKey,
      sourceOrder,
      slug,
      contentModule,
      title,
      summary,
      description,
      groupId,
      order,
      tags,
      html,
      excerpt,
      headings,
      sections,
    };
  });

  const sortedDocs = [...parsedDocs].sort((left, right) => {
    const leftGroupOrder = configuredGroups.get(left.groupId)?.order ?? 999;
    const rightGroupOrder = configuredGroups.get(right.groupId)?.order ?? 999;

    if (leftGroupOrder !== rightGroupOrder) {
      return leftGroupOrder - rightGroupOrder;
    }

    if (left.sourceOrder !== right.sourceOrder) {
      return left.sourceOrder - right.sourceOrder;
    }

    if (left.order !== right.order) {
      return left.order - right.order;
    }

    return left.title.localeCompare(right.title, "zh-CN");
  });

  const manifestDocs: DocManifestEntry[] = sortedDocs.map((doc) => ({
    slug: doc.slug,
    title: doc.title,
    summary: doc.summary,
    description: doc.description,
    groupId: doc.groupId,
    order: doc.order,
    tags: doc.tags,
    excerpt: doc.excerpt,
    headings: doc.headings,
    contentModule: doc.contentModule,
  }));

  const groups = groupsWithFallback
    .map((group) => ({
      id: group.id,
      title: group.title,
      icon: group.icon,
      order: group.order ?? 999,
      homeLinks: group.homeLinks ?? 4,
      docs: manifestDocs
        .filter((doc) => doc.groupId === group.id)
        .map((doc) => doc.slug),
    }))
    .filter((group) => group.docs.length > 0)
    .sort((left, right) => left.order - right.order);

  const searchIndex: SearchEntry[] = sortedDocs.flatMap((doc) => {
    const groupTitle = configuredGroups.get(doc.groupId)?.title ?? doc.groupId;
    const plainText = stripMarkdown(doc.rawContent);
    const docEntry: SearchEntry = {
      id: `doc:${doc.slug}`,
      kind: "doc",
      slug: doc.slug,
      title: doc.title,
      description: doc.summary,
      keywords: [groupTitle, doc.description, ...doc.tags, plainText].join(" "),
      scoreBoost: doc.sourceKey === "readme" ? 120 : 80,
    };

    const sectionEntries = doc.sections
      .filter((section) => section.level === 2 || section.level === 3)
      .map<SearchEntry>((section) => ({
        id: `section:${doc.slug}:${section.id}`,
        kind: "section",
        slug: doc.slug,
        sectionId: section.id,
        title: section.title,
        description: section.text.slice(0, 110) || doc.summary,
        keywords: [
          doc.title,
          groupTitle,
          doc.summary,
          ...doc.tags,
          section.text,
        ].join(" "),
        scoreBoost: 48,
      }));

    return [docEntry, ...sectionEntries];
  });

  fs.rmSync(generatedRootDir, { recursive: true, force: true });
  ensureDirectory(generatedContentDir);

  for (const doc of sortedDocs) {
    writeTypeScriptModule(
      path.join(generatedContentDir, `${doc.contentModule}.ts`),
      createContentModule(doc.slug, doc.html),
    );
  }

  const defaultDocSlug =
    manifestDocs.find((doc) => doc.slug === "guide/overview")?.slug ??
    manifestDocs[0]?.slug ??
    "";

  writeTypeScriptModule(
    manifestPath,
    createManifestModule({
      config: siteConfig,
      groups,
      docs: manifestDocs,
      searchIndex,
      defaultDocSlug,
    }),
  );

  console.log(`Generated ${manifestDocs.length} documents.`);
}

main();
