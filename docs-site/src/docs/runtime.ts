import { docsManifest } from "./generated/manifest";
import type {
  DocContent,
  DocGroup,
  DocManifest,
  SearchEntry,
  SearchResult,
} from "./types";

const contentModules = import.meta.glob("./generated/content/*.ts");
const contentCache = new Map<string, Promise<DocContent>>();
const docsMap = new Map<string, DocManifest>(
  docsManifest.docs.map((doc) => [doc.slug, doc]),
);
const groupsMap = new Map<string, DocGroup>(
  docsManifest.groups.map((group) => [group.id, group]),
);

type SearchModule = {
  searchIndex: SearchEntry[];
};

type NormalizedSearchEntry = SearchEntry & {
  normalizedTitle: string;
  normalizedDescription: string;
  normalizedKeywords: string;
  normalizedSlug: string;
};

let searchIndexPromise: Promise<NormalizedSearchEntry[]> | undefined;

function normalizeText(value: string) {
  return value
    .normalize("NFKD")
    .replace(/[\u0300-\u036f]/g, "")
    .toLowerCase()
    .replace(/\s+/g, " ")
    .trim();
}

function getSearchIndexModule() {
  if (!searchIndexPromise) {
    searchIndexPromise = import("./generated/search").then((module) => {
      const resolvedModule = module as SearchModule;
      return resolvedModule.searchIndex.map((entry) => ({
        ...entry,
        normalizedTitle: normalizeText(entry.title),
        normalizedDescription: normalizeText(entry.description),
        normalizedKeywords: normalizeText(entry.keywords),
        normalizedSlug: normalizeText(entry.slug),
      }));
    });
  }

  return searchIndexPromise;
}

export { docsManifest };

export function getDocsMap() {
  return docsMap;
}

export function getGroupMap() {
  return groupsMap;
}

export function preloadSearchIndex() {
  return getSearchIndexModule();
}

export async function searchDocs(query: string, limit = 8) {
  const normalizedQuery = normalizeText(query);

  if (!normalizedQuery) {
    return [] as SearchResult[];
  }

  const tokens = Array.from(
    new Set(
      normalizedQuery
        .split(/[\s/_.-]+/)
        .map((token) => token.trim())
        .filter(Boolean),
    ),
  );
  const searchIndex = await getSearchIndexModule();

  return searchIndex
    .map((entry) => {
      let score = entry.scoreBoost;
      let matchedAll = true;

      if (entry.normalizedTitle.includes(normalizedQuery)) score += 120;
      if (entry.normalizedDescription.includes(normalizedQuery)) score += 40;
      if (entry.normalizedKeywords.includes(normalizedQuery)) score += 30;
      if (entry.normalizedSlug.includes(normalizedQuery)) score += 24;

      for (const token of tokens) {
        let tokenMatched = false;

        if (entry.normalizedTitle.includes(token)) {
          score += 60;
          tokenMatched = true;
        }

        if (entry.normalizedDescription.includes(token)) {
          score += 20;
          tokenMatched = true;
        }

        if (entry.normalizedKeywords.includes(token)) {
          score += 14;
          tokenMatched = true;
        }

        if (entry.normalizedSlug.includes(token)) {
          score += 18;
          tokenMatched = true;
        }

        if (!tokenMatched) {
          matchedAll = false;
          break;
        }
      }

      if (!matchedAll) {
        return null;
      }

      const result: SearchResult = {
        id: entry.id,
        kind: entry.kind,
        slug: entry.slug,
        title: entry.title,
        description: entry.description,
        keywords: entry.keywords,
        scoreBoost: entry.scoreBoost,
        score,
      };

      if (entry.sectionId) {
        result.sectionId = entry.sectionId;
      }

      return result;
    })
    .filter((entry): entry is SearchResult => Boolean(entry))
    .sort((left, right) => {
      if (right.score !== left.score) {
        return right.score - left.score;
      }

      if (left.kind !== right.kind) {
        return left.kind === "doc" ? -1 : 1;
      }

      return left.title.localeCompare(right.title, "zh-CN");
    })
    .slice(0, limit);
}

export async function loadDocContentBySlug(slug: string) {
  const doc = docsMap.get(slug);

  if (!doc) {
    throw new Error(`Document not found: ${slug}`);
  }

  if (!contentCache.has(doc.contentModule)) {
    const modulePath = `./generated/content/${doc.contentModule}.ts`;
    const loader = contentModules[modulePath];

    if (!loader) {
      throw new Error(`Missing generated module: ${modulePath}`);
    }

    contentCache.set(
      doc.contentModule,
      loader().then((module) => {
        const resolvedModule = module as { default: DocContent };
        return resolvedModule.default;
      }),
    );
  }

  return contentCache.get(doc.contentModule)!;
}

export function prefetchDocContent(slug?: string) {
  if (!slug) {
    return;
  }

  void loadDocContentBySlug(slug);
}

export function getRouteState(defaultDocSlug: string) {
  const params = new URLSearchParams(window.location.search);
  const rawSlug = params.get("doc");
  const slug = rawSlug && docsMap.has(rawSlug) ? rawSlug : defaultDocSlug;
  const sectionId = params.get("section") ?? undefined;

  return {
    view: rawSlug ? ("doc" as const) : ("home" as const),
    slug,
    sectionId,
  };
}

export function syncRouteState(options: {
  view: "home" | "doc";
  slug?: string;
  sectionId?: string;
  replace?: boolean;
}) {
  const url = new URL(window.location.href);

  if (options.view === "doc" && options.slug) {
    url.searchParams.set("doc", options.slug);

    if (options.sectionId) {
      url.searchParams.set("section", options.sectionId);
    } else {
      url.searchParams.delete("section");
    }
  } else {
    url.searchParams.delete("doc");
    url.searchParams.delete("section");
  }

  if (options.replace) {
    window.history.replaceState({}, "", url);
    return;
  }

  window.history.pushState({}, "", url);
}

export function buildDocUrl(slug?: string, sectionId?: string) {
  const url = new URL(window.location.href);

  if (slug) {
    url.searchParams.set("doc", slug);
  } else {
    url.searchParams.delete("doc");
  }

  if (sectionId) {
    url.searchParams.set("section", sectionId);
  } else {
    url.searchParams.delete("section");
  }

  return url.toString();
}
