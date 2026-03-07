import {docsManifest} from './generated/manifest';
import type {DocContent, DocGroup, DocManifest, SearchEntry} from './types';

const contentModules = import.meta.glob('./generated/content/*.ts');
const contentCache = new Map<string, Promise<DocContent>>();

function normalizeText(value: string) {
  return value
    .normalize('NFKD')
    .replace(/[\u0300-\u036f]/g, '')
    .toLowerCase()
    .replace(/\s+/g, ' ')
    .trim();
}

export {docsManifest};

export function getDocsMap() {
  return new Map<string, DocManifest>(docsManifest.docs.map((doc) => [doc.slug, doc]));
}

export function getGroupMap() {
  return new Map<string, DocGroup>(docsManifest.groups.map((group) => [group.id, group]));
}

export function searchDocs(query: string, limit = 8) {
  const normalizedQuery = normalizeText(query);

  if (!normalizedQuery) {
    return [] as Array<SearchEntry & {score: number}>;
  }

  const tokens = Array.from(
    new Set(normalizedQuery.split(/[\s/_.-]+/).map((token) => token.trim()).filter(Boolean)),
  );

  return docsManifest.searchIndex
    .map((entry) => {
      const title = normalizeText(entry.title);
      const description = normalizeText(entry.description);
      const keywords = normalizeText(entry.keywords);
      const slug = normalizeText(entry.slug);

      let score = entry.scoreBoost;
      let matchedAll = true;

      if (title.includes(normalizedQuery)) score += 120;
      if (description.includes(normalizedQuery)) score += 40;
      if (keywords.includes(normalizedQuery)) score += 30;
      if (slug.includes(normalizedQuery)) score += 24;

      for (const token of tokens) {
        let tokenMatched = false;

        if (title.includes(token)) {
          score += 60;
          tokenMatched = true;
        }

        if (description.includes(token)) {
          score += 20;
          tokenMatched = true;
        }

        if (keywords.includes(token)) {
          score += 14;
          tokenMatched = true;
        }

        if (slug.includes(token)) {
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

      return {
        ...entry,
        score,
      };
    })
    .filter((entry): entry is SearchEntry & {score: number} => Boolean(entry))
    .sort((left, right) => {
      if (right.score !== left.score) {
        return right.score - left.score;
      }

      if (left.kind !== right.kind) {
        return left.kind === 'doc' ? -1 : 1;
      }

      return left.title.localeCompare(right.title, 'zh-CN');
    })
    .slice(0, limit);
}

export async function loadDocContentBySlug(slug: string) {
  const doc = docsManifest.docs.find((item) => item.slug === slug);

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
        const resolvedModule = module as {default: DocContent};
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
  const rawSlug = params.get('doc');
  const slug = docsManifest.docs.some((doc) => doc.slug === rawSlug) ? rawSlug! : defaultDocSlug;
  const sectionId = params.get('section') ?? undefined;

  return {
    view: rawSlug ? ('doc' as const) : ('home' as const),
    slug,
    sectionId,
  };
}

export function syncRouteState(options: {
  view: 'home' | 'doc';
  slug?: string;
  sectionId?: string;
  replace?: boolean;
}) {
  const url = new URL(window.location.href);

  if (options.view === 'doc' && options.slug) {
    url.searchParams.set('doc', options.slug);

    if (options.sectionId) {
      url.searchParams.set('section', options.sectionId);
    } else {
      url.searchParams.delete('section');
    }
  } else {
    url.searchParams.delete('doc');
    url.searchParams.delete('section');
  }

  if (options.replace) {
    window.history.replaceState({}, '', url);
    return;
  }

  window.history.pushState({}, '', url);
}

export function buildDocUrl(slug?: string, sectionId?: string) {
  const url = new URL(window.location.href);

  if (slug) {
    url.searchParams.set('doc', slug);
  } else {
    url.searchParams.delete('doc');
  }

  if (sectionId) {
    url.searchParams.set('section', sectionId);
  } else {
    url.searchParams.delete('section');
  }

  return url.toString();
}
