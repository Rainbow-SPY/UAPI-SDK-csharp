export type IconName =
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

export interface SiteBrandGithubConfig {
  href: string;
  title?: string;
  openInNewTab?: boolean;
}

export interface SiteBrandVersionMenuConfig {
  enabled?: boolean;
  label: string;
  items: string[];
}

export interface SiteBrandConfig {
  name: string;
  browserTitle?: string;
  versionLabel?: string;
  versions?: string[];
  versionMenu?: SiteBrandVersionMenuConfig;
  github?: SiteBrandGithubConfig;
}

export interface SiteHeroConfig {
  title: string;
  description: string;
}

export interface SiteRepositoryConfig {
  contentRoot?: string;
  defaultBranch?: string;
}

export interface SiteGroupConfig {
  id: string;
  title: string;
  icon: IconName;
  order?: number;
  homeLinks?: number;
  sources?: string[];
}

export interface SiteConfig {
  brand: SiteBrandConfig;
  hero: SiteHeroConfig;
  repository?: SiteRepositoryConfig;
  groups: SiteGroupConfig[];
}

export interface DocHeading {
  id: string;
  text: string;
  level: number;
}

export interface DocManifest {
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

export interface SearchEntry {
  id: string;
  kind: "doc" | "section";
  slug: string;
  sectionId?: string;
  title: string;
  description: string;
  keywords: string;
  scoreBoost: number;
}

export interface DocGroup {
  id: string;
  title: string;
  icon: IconName;
  order: number;
  homeLinks: number;
  docs: string[];
}

export interface DocsManifest {
  config: SiteConfig;
  groups: DocGroup[];
  docs: DocManifest[];
  searchIndex: SearchEntry[];
  defaultDocSlug: string;
}

export interface DocContent {
  slug: string;
  html: string;
}
