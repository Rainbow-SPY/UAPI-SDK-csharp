import React, { useEffect, useMemo, useRef, useState } from "react";
import {
  Github,
  Search,
  Globe,
  ChevronDown,
  ChevronRight,
  Copy,
  ArrowLeft,
  ArrowRight,
  Sun,
  Moon,
  Check,
  Rocket,
  MessageSquare,
  Settings,
  Shield,
  Layout,
  Building,
  Cpu,
  Info,
} from "lucide-react";
import { AnimatePresence, motion } from "motion/react";
import {
  buildDocUrl,
  docsManifest,
  getDocsMap,
  getGroupMap,
  getRouteState,
  loadDocContentBySlug,
  prefetchDocContent,
  searchDocs,
  syncRouteState,
} from "./docs/runtime";
import type { DocGroup, DocManifest, IconName } from "./docs/types";
const iconMap: Record<IconName, React.ComponentType<{ className?: string }>> = {
  Rocket,
  MessageSquare,
  Settings,
  Shield,
  Layout,
  Building,
  Cpu,
  Search,
  Globe,
  Info,
};
export default function App() {
  const initialRoute = useRef(getRouteState(docsManifest.defaultDocSlug));
  const docsMap = useMemo(() => getDocsMap(), []);
  const groupsMap = useMemo(() => getGroupMap(), []);
  const [isDark, setIsDark] = useState(false);
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);
  const [currentView, setCurrentView] = useState<"home" | "doc">(
    initialRoute.current.view,
  );
  const [activeSlug, setActiveSlug] = useState(initialRoute.current.slug);
  const [pendingSectionId, setPendingSectionId] = useState<string | undefined>(
    initialRoute.current.sectionId,
  );
  const [searchQuery, setSearchQuery] = useState("");
  const [isSearchOpen, setIsSearchOpen] = useState(false);
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);
  const [isTocOpen, setIsTocOpen] = useState(false);
  const [copied, setCopied] = useState(false);
  const [activeHtml, setActiveHtml] = useState("");
  const [isLoadingDoc, setIsLoadingDoc] = useState(
    initialRoute.current.view === "doc",
  );
  const [docLoadError, setDocLoadError] = useState("");
  const [openGroups, setOpenGroups] = useState<Record<string, boolean>>(() =>
    Object.fromEntries(docsManifest.groups.map((group) => [group.id, true])),
  );
  const contentScrollRef = useRef<HTMLElement | null>(null);
  const searchRef = useRef<HTMLDivElement | null>(null);
  const headerGithub = docsManifest.config.brand.github;
  const shouldShowHeaderGithub = Boolean(headerGithub?.href);
  const browserTitle =
    docsManifest.config.brand.browserTitle ?? docsManifest.config.brand.name;
  const legacyVersionMenu =
    docsManifest.config.brand.versionLabel &&
    docsManifest.config.brand.versions?.length
      ? {
          enabled: true,
          label: docsManifest.config.brand.versionLabel,
          items: docsManifest.config.brand.versions,
        }
      : undefined;
  const headerVersionMenu =
    docsManifest.config.brand.versionMenu ?? legacyVersionMenu;
  const headerVersionMenuItems = headerVersionMenu?.items ?? [];
  const shouldShowVersionMenu = Boolean(
    headerVersionMenu &&
      headerVersionMenu.enabled !== false &&
      headerVersionMenu.label?.trim() &&
      headerVersionMenuItems.length > 0,
  );
  const activeDoc = docsMap.get(activeSlug) ?? docsManifest.docs[0];
  const activeGroup = groupsMap.get(activeDoc.groupId);
  const activeDocIndex = docsManifest.docs.findIndex(
    (doc) => doc.slug === activeDoc.slug,
  );
  const previousDoc =
    activeDocIndex > 0 ? docsManifest.docs[activeDocIndex - 1] : undefined;
  const nextDoc =
    activeDocIndex >= 0 && activeDocIndex < docsManifest.docs.length - 1
      ? docsManifest.docs[activeDocIndex + 1]
      : undefined;
  const searchResults = useMemo(() => searchDocs(searchQuery), [searchQuery]);
  const closeResponsivePanels = () => {
    setIsSidebarOpen(false);
    setIsTocOpen(false);
  };
  const homeGroups = useMemo(
    () =>
      docsManifest.groups.map((group) => ({
        ...group,
        docItems: group.docs
          .map((slug) => docsMap.get(slug))
          .filter((doc): doc is DocManifest => Boolean(doc))
          .slice(0, group.homeLinks),
      })),
    [docsMap],
  );
  useEffect(() => {
    const storedTheme = window.localStorage.getItem("docs-theme");
    if (storedTheme === "dark" || storedTheme === "light") {
      setIsDark(storedTheme === "dark");
      return;
    }
    setIsDark(window.matchMedia("(prefers-color-scheme: dark)").matches);
  }, []);
  useEffect(() => {
    window.localStorage.setItem("docs-theme", isDark ? "dark" : "light");
  }, [isDark]);
  useEffect(() => {
    const handleWindowClick = (event: MouseEvent) => {
      if (searchRef.current?.contains(event.target as Node)) {
        return;
      }
      setIsSearchOpen(false);
    };
    window.addEventListener("click", handleWindowClick);
    return () => window.removeEventListener("click", handleWindowClick);
  }, []);
  useEffect(() => {
    const handlePopState = () => {
      const routeState = getRouteState(docsManifest.defaultDocSlug);
      setCurrentView(routeState.view);
      setActiveSlug(routeState.slug);
      setPendingSectionId(routeState.sectionId);
      closeResponsivePanels();
      const routeDoc = docsMap.get(routeState.slug);
      if (routeDoc) {
        setOpenGroups((previous) => ({
          ...previous,
          [routeDoc.groupId]: true,
        }));
      }
    };
    window.addEventListener("popstate", handlePopState);
    return () => window.removeEventListener("popstate", handlePopState);
  }, [docsMap]);
  useEffect(() => {
    if (currentView !== "doc") {
      return;
    }
    let disposed = false;
    setIsLoadingDoc(true);
    setDocLoadError("");
    void loadDocContentBySlug(activeSlug)
      .then((content) => {
        if (disposed) {
          return;
        }
        setActiveHtml(content.html);
        setIsLoadingDoc(false);
      })
      .catch((error) => {
        if (disposed) {
          return;
        }
        setDocLoadError(
          error instanceof Error ? error.message : "Failed to load document.",
        );
        setIsLoadingDoc(false);
      });
    return () => {
      disposed = true;
    };
  }, [activeSlug, currentView]);
  useEffect(() => {
    if (currentView !== "doc") {
      document.title = browserTitle;
      return;
    }
    document.title = `${activeDoc.title} - ${browserTitle}`;
  }, [activeDoc.title, browserTitle, currentView]);
  useEffect(() => {
    if (currentView !== "doc" || isLoadingDoc) {
      return;
    }
    if (pendingSectionId) {
      window.requestAnimationFrame(() => {
        document
          .getElementById(pendingSectionId)
          ?.scrollIntoView({ behavior: "smooth", block: "start" });
      });
      return;
    }
    contentScrollRef.current?.scrollTo({ top: 0, behavior: "auto" });
  }, [activeHtml, currentView, isLoadingDoc, pendingSectionId]);
  useEffect(() => {
    prefetchDocContent(previousDoc?.slug);
    prefetchDocContent(nextDoc?.slug);
  }, [nextDoc?.slug, previousDoc?.slug]);
  const openDoc = (slug: string, sectionId?: string, replace = false) => {
    const targetDoc = docsMap.get(slug) ?? docsManifest.docs[0];
    setCurrentView("doc");
    setActiveSlug(targetDoc.slug);
    setPendingSectionId(sectionId);
    setSearchQuery("");
    setIsSearchOpen(false);
    closeResponsivePanels();
    setOpenGroups((previous) => ({ ...previous, [targetDoc.groupId]: true }));
    syncRouteState({ view: "doc", slug: targetDoc.slug, sectionId, replace });
  };
  const goHome = () => {
    setCurrentView("home");
    setPendingSectionId(undefined);
    setSearchQuery("");
    setIsSearchOpen(false);
    closeResponsivePanels();
    syncRouteState({ view: "home" });
  };
  const handleCopyPage = async () => {
    try {
      await navigator.clipboard.writeText(
        buildDocUrl(activeSlug, pendingSectionId),
      );
      setCopied(true);
      window.setTimeout(() => setCopied(false), 1800);
    } catch {
      setCopied(false);
    }
  };
  const handleSearchEnter = (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key !== "Enter" || searchResults.length === 0) {
      return;
    }
    const firstResult = searchResults[0];
    openDoc(firstResult.slug, firstResult.sectionId);
  };
  const handleArticleClick = (event: React.MouseEvent<HTMLElement>) => {
    const target = event.target as HTMLElement;
    const anchor = target.closest(
      "a[data-doc-slug]",
    ) as HTMLAnchorElement | null;
    if (!anchor) {
      return;
    }
    event.preventDefault();
    openDoc(anchor.dataset.docSlug ?? activeSlug, anchor.dataset.docSection);
  };
  return (
    <div className={isDark ? "dark" : ""}>
      {" "}
      <div className="min-h-dvh bg-[var(--bg-header)] transition-colors duration-500 md:h-screen">
        {" "}
        <div className="flex min-h-dvh min-h-0 flex-col bg-[var(--bg-header)] font-mono text-sm text-[var(--text-main)] transition-colors duration-500 md:h-full">
          {" "}
          <header className="relative z-50 grid shrink-0 grid-cols-[minmax(0,1fr)_auto] items-center gap-3 bg-[var(--bg-header)] px-4 py-3 transition-colors duration-500 md:h-14 md:grid-cols-[minmax(0,1fr)_minmax(280px,640px)_minmax(0,1fr)] md:px-6 md:py-0">
            {" "}
            <div className="flex min-w-0 items-center gap-2 sm:gap-3 md:gap-4 md:justify-self-start">
              {" "}
              <button
                onClick={goHome}
                className="flex min-w-0 items-center gap-2 text-[var(--text-strong)] transition-colors hover:text-[var(--text-muted)]"
                type="button"
              >
                {" "}
                {!shouldShowHeaderGithub ? (
                  <Github className="h-8 w-8 shrink-0" />
                ) : null}{" "}
                <span className="truncate text-lg font-semibold tracking-tight">
                  {docsManifest.config.brand.name}
                </span>{" "}
              </button>{" "}
              {shouldShowVersionMenu ? (
                <>
                  {" "}
                  <div className="mx-1 hidden h-6 w-px bg-[var(--border-subtle)] transition-colors duration-500 md:mx-2 md:block" />{" "}
                  <div className="relative min-w-0">
                    {" "}
                    <button
                      onClick={() => setIsDropdownOpen((previous) => !previous)}
                      className={`flex max-w-full items-center gap-1.5 rounded-md px-3 py-1.5 text-sm font-medium transition-colors ${isDropdownOpen ? "bg-[var(--bg-hover)] text-[var(--text-strong)]" : "text-[var(--text-main)] hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"}`}
                      type="button"
                    >
                      {" "}
                      <span className="truncate">{headerVersionMenu!.label}</span>{" "}
                      <ChevronDown
                        className={`h-4 w-4 shrink-0 transition-transform duration-300 ${isDropdownOpen ? "rotate-180" : ""}`}
                      />{" "}
                    </button>{" "}
                    <AnimatePresence>
                      {" "}
                      {isDropdownOpen ? (
                        <>
                          {" "}
                          <div
                            className="fixed inset-0 z-40"
                            onClick={() => setIsDropdownOpen(false)}
                          />{" "}
                          <motion.div
                            initial={{ opacity: 0, y: -8, scale: 0.96 }}
                            animate={{ opacity: 1, y: 0, scale: 1 }}
                            exit={{ opacity: 0, y: -8, scale: 0.96 }}
                            transition={{ duration: 0.15, ease: "easeOut" }}
                            className="absolute left-0 top-full z-50 mt-2 flex w-64 max-w-[calc(100vw-2rem)] flex-col overflow-hidden rounded-xl border border-[var(--border-subtle)] bg-[var(--bg-main)] p-1.5"
                            style={{ boxShadow: "var(--shadow-dropdown)" }}
                          >
                            {" "}
                            {headerVersionMenuItems.map((version, index) => (
                              <button
                                key={version}
                                type="button"
                                className={`flex items-center justify-between rounded-lg px-3 py-2 text-left text-sm transition-colors ${index === 0 ? "bg-[var(--accent-bg)] font-medium text-[var(--accent)]" : "text-[var(--text-main)] hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"}`}
                              >
                                {" "}
                                <span className="truncate">{version}</span>{" "}
                                {index === 0 ? (
                                  <Check className="h-4 w-4 shrink-0" />
                                ) : null}{" "}
                              </button>
                            ))}{" "}
                          </motion.div>{" "}
                        </>
                      ) : null}{" "}
                    </AnimatePresence>{" "}
                  </div>{" "}
                </>
              ) : null}{" "}
            </div>{" "}
            <div
              className="col-span-2 row-start-2 mx-auto flex w-full md:col-span-1 md:row-start-auto md:max-w-none"
              ref={searchRef}
            >
              {" "}
              <div className="group relative flex w-full items-center">
                {" "}
                <Search className="absolute left-3 h-4 w-4 text-[var(--text-muted)] transition-colors group-focus-within:text-[var(--accent)]" />{" "}
                <input
                  type="text"
                  value={searchQuery}
                  onChange={(event) => {
                    setSearchQuery(event.target.value);
                    setIsSearchOpen(Boolean(event.target.value.trim()));
                  }}
                  onFocus={() => setIsSearchOpen(Boolean(searchQuery.trim()))}
                  onKeyDown={handleSearchEnter}
                  placeholder="Search APIs, docs, and keywords"
                  className="w-full rounded-2xl border border-[var(--border-subtle)] bg-[var(--bg-main)] py-1.5 pl-9 pr-3 text-sm focus:border-[var(--accent)] focus:outline-none"
                />{" "}
                <AnimatePresence>
                  {" "}
                  {isSearchOpen && searchResults.length > 0 ? (
                    <motion.div
                      initial={{ opacity: 0, y: -8 }}
                      animate={{ opacity: 1, y: 0 }}
                      exit={{ opacity: 0, y: -8 }}
                      transition={{ duration: 0.12, ease: "easeOut" }}
                      className="custom-scrollbar absolute left-0 top-full z-50 mt-2 max-h-[420px] w-full overflow-y-auto rounded-xl border border-[var(--border-subtle)] bg-[var(--bg-main)] p-2"
                      style={{ boxShadow: "var(--shadow-dropdown)" }}
                    >
                      {" "}
                      {searchResults.map((result) => (
                        <button
                          key={result.id}
                          type="button"
                          onClick={() => openDoc(result.slug, result.sectionId)}
                          className="flex w-full flex-col items-start gap-1 rounded-lg px-3 py-2 text-left transition-colors hover:bg-[var(--bg-hover)]"
                        >
                          {" "}
                          <div className="flex w-full items-center justify-between gap-3">
                            {" "}
                            <span className="font-medium text-[var(--text-strong)]">
                              {result.title}
                            </span>{" "}
                            <span className="text-xs uppercase tracking-wide text-[var(--text-muted)]">
                              {" "}
                              {result.kind === "doc" ? "Doc" : "Section"}{" "}
                            </span>{" "}
                          </div>{" "}
                          <span className="line-clamp-2 text-sm text-[var(--text-main)]">
                            {result.description}
                          </span>{" "}
                        </button>
                      ))}{" "}
                    </motion.div>
                  ) : null}{" "}
                </AnimatePresence>{" "}
              </div>{" "}
            </div>{" "}
            <div className="flex items-center justify-end gap-2 md:justify-self-end">
              {" "}
              {shouldShowHeaderGithub ? (
                <a
                  href={headerGithub!.href}
                  title={headerGithub?.title ?? "Open GitHub"}
                  aria-label={headerGithub?.title ?? "Open GitHub"}
                  target={
                    headerGithub?.openInNewTab === false ? undefined : "_blank"
                  }
                  rel={
                    headerGithub?.openInNewTab === false
                      ? undefined
                      : "noreferrer"
                  }
                  className="rounded-md p-2 text-[var(--text-muted)] transition-colors hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"
                >
                  {" "}
                  <Github className="h-5 w-5" />{" "}
                </a>
              ) : null}{" "}
              <button
                onClick={() => setIsDark((previous) => !previous)}
                className="rounded-md p-2 text-[var(--text-muted)] transition-colors hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"
                type="button"
              >
                {" "}
                {isDark ? (
                  <Sun className="h-5 w-5" />
                ) : (
                  <Moon className="h-5 w-5" />
                )}{" "}
              </button>{" "}
            </div>{" "}
          </header>{" "}
          <div className="flex-1 min-h-0 bg-[var(--bg-header)] px-3 pb-3 transition-colors duration-500 sm:px-4 sm:pb-4">
            {" "}
            <div className="flex h-full min-h-0 overflow-hidden rounded-[20px] bg-[var(--bg-main)] transition-colors duration-500 sm:rounded-[24px]">
              {" "}
              {currentView === "home" ? (
                <main className="custom-scrollbar flex-1 overflow-y-auto bg-[var(--bg-main)] transition-colors duration-500">
                  {" "}
                  <div className="flex flex-col items-center justify-center bg-[var(--bg-main)] px-4 py-16 text-center transition-colors duration-500 sm:px-6 md:py-24 lg:py-32">
                    {" "}
                    <h1 className="mb-6 font-sans text-4xl font-semibold tracking-tight text-[var(--text-strong)] transition-colors sm:text-5xl md:text-6xl">
                      {" "}
                      {docsManifest.config.hero.title}{" "}
                    </h1>{" "}
                    <p className="max-w-4xl px-2 text-base font-light text-[var(--text-muted)] transition-colors sm:px-6 sm:text-lg md:text-xl">
                      {" "}
                      {docsManifest.config.hero.description}{" "}
                    </p>{" "}
                  </div>{" "}
                  <div className="mx-auto max-w-[1400px] px-4 py-10 sm:px-6 md:py-14 lg:px-8 lg:py-16">
                    {" "}
                    <div className="grid grid-cols-1 gap-x-8 gap-y-16 md:grid-cols-2 lg:grid-cols-4">
                      {" "}
                      {homeGroups.map((group) => (
                        <CategorySection
                          key={group.id}
                          group={group}
                          onOpenDoc={openDoc}
                        />
                      ))}{" "}
                    </div>{" "}
                  </div>{" "}
                </main>
              ) : (
                <div className="relative flex flex-1 overflow-hidden">
                  {(isSidebarOpen || isTocOpen) && currentView === "doc" ? (
                    <button
                      aria-label="Close panels"
                      className="absolute inset-0 z-20 bg-black/20 xl:hidden"
                      onClick={closeResponsivePanels}
                      type="button"
                    />
                  ) : null}{" "}
                  <aside
                    className={`scrollbar-none absolute inset-y-0 left-0 z-30 flex w-[328px] max-w-[85vw] flex-col overflow-y-auto border-r border-[var(--border-subtle)] bg-[var(--bg-main)] shadow-[0_24px_48px_-24px_rgba(0,0,0,0.35)] transition-all duration-300 lg:static lg:z-auto lg:w-[328px] lg:max-w-none lg:translate-x-0 lg:shadow-none ${isSidebarOpen ? "translate-x-0" : "-translate-x-full lg:translate-x-0"}`}
                  >
                    {" "}
                    <div className="sticky top-0 z-10 border-b border-[var(--border-subtle)] bg-[var(--bg-main)] p-4 transition-colors duration-500 sm:p-5">
                      {" "}
                      <div className="mb-4 flex items-center justify-between gap-3">
                        <button
                          onClick={goHome}
                          className="flex items-center gap-2 text-sm text-[var(--text-muted)] transition-colors hover:text-[var(--text-strong)]"
                          type="button"
                        >
                          {" "}
                          <ArrowLeft className="h-4 w-4" /> Home{" "}
                        </button>{" "}
                        <button
                          onClick={() => setIsSidebarOpen(false)}
                          className="text-sm text-[var(--text-muted)] transition-colors hover:text-[var(--text-strong)] lg:hidden"
                          type="button"
                        >
                          Close
                        </button>
                      </div>{" "}
                      <h2 className="text-2xl font-semibold tracking-tight text-[var(--text-strong)] transition-colors">
                        {" "}
                        {docsManifest.config.brand.name}{" "}
                      </h2>{" "}
                    </div>{" "}
                    <nav className="flex-1 p-4 sm:p-5">
                      {" "}
                      <ul className="space-y-2">
                        {" "}
                        {docsManifest.groups.map((group) => (
                          <SidebarGroup
                            key={group.id}
                            group={group}
                            docsMap={docsMap}
                            isOpen={openGroups[group.id] ?? true}
                            activeSlug={activeDoc.slug}
                            onToggle={() =>
                              setOpenGroups((previous) => ({
                                ...previous,
                                [group.id]: !(previous[group.id] ?? true),
                              }))
                            }
                            onOpenDoc={openDoc}
                          />
                        ))}{" "}
                      </ul>{" "}
                    </nav>{" "}
                  </aside>{" "}
                  <main
                    ref={contentScrollRef}
                    className="scrollbar-none flex min-w-0 flex-1 justify-center overflow-y-auto p-4 sm:p-6 lg:p-10"
                  >
                    {" "}
                    <article
                      className="w-full max-w-[800px] pb-24 sm:pb-32 lg:pb-40"
                      onClick={handleArticleClick}
                    >
                      <div className="mb-6 flex flex-wrap items-center gap-2 lg:mb-8 xl:hidden">
                        <button
                          onClick={() => setIsSidebarOpen(true)}
                          className="rounded-md border border-[var(--border-subtle)] bg-[var(--bg-main)] px-3 py-2 text-sm text-[var(--text-main)] transition-colors hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)] lg:hidden"
                          type="button"
                        >
                          Browse
                        </button>
                        {activeDoc.headings.length > 0 ? (
                          <button
                            onClick={() => setIsTocOpen(true)}
                            className="rounded-md border border-[var(--border-subtle)] bg-[var(--bg-main)] px-3 py-2 text-sm text-[var(--text-main)] transition-colors hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"
                            type="button"
                          >
                            On this page
                          </button>
                        ) : null}
                        <button
                          onClick={handleCopyPage}
                          className="rounded-md border border-[var(--border-subtle)] bg-[var(--bg-main)] px-3 py-2 text-sm text-[var(--text-main)] transition-colors hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"
                          type="button"
                        >
                          {copied ? "Link copied" : "Copy page link"}
                        </button>
                      </div>{" "}
                      <nav className="mb-8 flex flex-wrap items-center gap-2 text-sm text-[var(--text-muted)] transition-colors">
                        {" "}
                        <button
                          onClick={goHome}
                          className="transition-colors hover:text-[var(--accent)] hover:underline"
                          type="button"
                        >
                          {" "}
                          Home{" "}
                        </button>{" "}
                        <span>/</span>{" "}
                        <span>{activeGroup?.title ?? activeDoc.groupId}</span>{" "}
                        <span>/</span> <span>{activeDoc.title}</span>{" "}
                      </nav>{" "}
                      <header className="mb-8 pb-6 transition-colors duration-500 sm:mb-10 sm:pb-8">
                        {" "}
                        <div className="mb-4 inline-flex rounded-full bg-[var(--accent-bg)] px-3 py-1 text-xs font-medium tracking-wide text-[var(--accent)]">
                          {" "}
                          {activeGroup?.title ?? activeDoc.groupId}{" "}
                        </div>{" "}
                        <h1 className="mb-4 text-4xl font-semibold tracking-tight text-[var(--text-strong)] transition-colors duration-500 sm:text-5xl">
                          {" "}
                          {activeDoc.title}{" "}
                        </h1>{" "}
                        <p className="text-base leading-relaxed text-[var(--text-main)] transition-colors duration-500 sm:text-lg">
                          {" "}
                          {activeDoc.description}{" "}
                        </p>{" "}
                      </header>{" "}
                      {isLoadingDoc ? (
                        <div className="space-y-4">
                          {" "}
                          <div className="h-6 w-40 animate-pulse rounded bg-[var(--bg-hover)]" />{" "}
                          <div className="h-4 w-full animate-pulse rounded bg-[var(--bg-hover)]" />{" "}
                          <div className="h-4 w-11/12 animate-pulse rounded bg-[var(--bg-hover)]" />{" "}
                          <div className="h-4 w-10/12 animate-pulse rounded bg-[var(--bg-hover)]" />{" "}
                        </div>
                      ) : docLoadError ? (
                        <div className="rounded-2xl border border-[var(--border-subtle)] bg-[var(--bg-hover)] p-6 text-[var(--text-main)]">
                          {" "}
                          {docLoadError}{" "}
                        </div>
                      ) : (
                        <div
                          className="doc-content"
                          dangerouslySetInnerHTML={{ __html: activeHtml }}
                        />
                      )}{" "}
                      <div className="mt-12 grid grid-cols-1 gap-4 border-t border-[var(--border-subtle)] pt-6 md:grid-cols-2">
                        {" "}
                        <DocPagerCard
                          direction="prev"
                          doc={previousDoc}
                          groupMap={groupsMap}
                          onOpenDoc={openDoc}
                        />{" "}
                        <DocPagerCard
                          direction="next"
                          doc={nextDoc}
                          groupMap={groupsMap}
                          onOpenDoc={openDoc}
                        />{" "}
                      </div>{" "}
                      <div className="h-24 md:h-32" aria-hidden="true" />{" "}
                    </article>{" "}
                  </main>{" "}
                  <aside
                    className={`absolute inset-y-0 right-0 z-30 w-[250px] max-w-[85vw] overflow-y-auto bg-[var(--bg-main)] p-6 shadow-[0_24px_48px_-24px_rgba(0,0,0,0.35)] transition-all duration-300 xl:static xl:z-auto xl:block xl:max-w-none xl:translate-x-0 xl:p-8 xl:shadow-none ${isTocOpen ? "translate-x-0" : "translate-x-full xl:translate-x-0"}`}
                  >
                    {" "}
                    <div className="mb-6 flex items-center justify-between gap-3 xl:hidden">
                      <h3 className="text-sm font-semibold uppercase tracking-wide text-[var(--text-strong)] transition-colors">
                        On this page
                      </h3>
                      <button
                        onClick={() => setIsTocOpen(false)}
                        className="text-sm text-[var(--text-muted)] transition-colors hover:text-[var(--text-strong)]"
                        type="button"
                      >
                        Close
                      </button>
                    </div>
                    <button
                      onClick={handleCopyPage}
                      className="group mb-10 flex w-full items-center justify-start gap-2 bg-transparent p-0 text-left text-sm font-medium text-[var(--text-main)] transition-colors duration-300 hover:text-[var(--text-strong)]"
                      type="button"
                    >
                      {" "}
                      {copied ? (
                        <Check className="h-4 w-4 text-green-500" />
                      ) : (
                        <Copy className="h-4 w-4 text-[var(--text-muted)] transition-colors group-hover:text-[var(--text-strong)]" />
                      )}{" "}
                      {copied ? "Link copied" : "Copy page link"}{" "}
                    </button>{" "}
                    <h3 className="mb-4 text-sm font-semibold uppercase tracking-wide text-[var(--text-strong)] transition-colors">
                      {" "}
                      On this page{" "}
                    </h3>{" "}
                    <ul className="space-y-3 border-l-2 border-[var(--border-subtle)] pl-4 text-sm">
                      {" "}
                      {activeDoc.headings.map((heading) => (
                        <li key={heading.id}>
                          {" "}
                          <button
                            onClick={() => openDoc(activeDoc.slug, heading.id)}
                            className={`block text-left transition-colors hover:text-[var(--accent)] ${heading.level === 3 ? "pl-4 text-[var(--text-muted)]" : "text-[var(--text-main)]"}`}
                            type="button"
                          >
                            {" "}
                            {heading.text}{" "}
                          </button>{" "}
                        </li>
                      ))}{" "}
                    </ul>{" "}
                  </aside>{" "}
                </div>
              )}{" "}
            </div>{" "}
          </div>{" "}
        </div>{" "}
      </div>{" "}
    </div>
  );
}
function CategorySection({
  group,
  onOpenDoc,
}: {
  group: DocGroup & { docItems: DocManifest[] };
  onOpenDoc: (slug: string, sectionId?: string, replace?: boolean) => void;
}) {
  const Icon = iconMap[group.icon] ?? Info;
  return (
    <div className="flex flex-col">
      {" "}
      <h3 className="mb-5 flex items-center gap-3 text-lg font-semibold text-[var(--text-strong)] transition-colors">
        {" "}
        <span className="text-[var(--text-muted)]">
          {" "}
          <Icon className="h-5 w-5" />{" "}
        </span>{" "}
        {group.title}{" "}
      </h3>{" "}
      <ul className="flex flex-col space-y-3">
        {" "}
        {group.docItems.map((doc) => (
          <li key={doc.slug}>
            {" "}
            <button
              onClick={() => onOpenDoc(doc.slug)}
              className="text-left text-[15px] text-[var(--text-main)] transition-colors hover:text-[var(--accent)] hover:underline"
              type="button"
            >
              {" "}
              {doc.title}{" "}
            </button>{" "}
          </li>
        ))}{" "}
      </ul>{" "}
    </div>
  );
}
function SidebarGroup({
  group,
  docsMap,
  isOpen,
  activeSlug,
  onToggle,
  onOpenDoc,
}: {
  group: DocGroup;
  docsMap: Map<string, DocManifest>;
  isOpen: boolean;
  activeSlug: string;
  onToggle: () => void;
  onOpenDoc: (slug: string, sectionId?: string, replace?: boolean) => void;
}) {
  const Icon = iconMap[group.icon] ?? Info;
  return (
    <li>
      {" "}
      <button
        onClick={onToggle}
        className="flex w-full items-center justify-between rounded-md px-3 py-2 text-left font-medium text-[var(--text-strong)] transition-colors hover:bg-[var(--bg-hover)]"
        type="button"
      >
        {" "}
        <span className="flex items-center justify-end gap-2">
          {" "}
          <Icon className="h-4 w-4 text-[var(--text-muted)]" />{" "}
          {group.title}{" "}
        </span>{" "}
        <ChevronRight
          className={`h-4 w-4 text-[var(--text-muted)] transition-transform ${isOpen ? "rotate-90" : ""}`}
        />{" "}
      </button>{" "}
      <AnimatePresence initial={false}>
        {" "}
        {isOpen ? (
          <motion.ul
            initial={{ height: 0, opacity: 0 }}
            animate={{ height: "auto", opacity: 1 }}
            exit={{ height: 0, opacity: 0 }}
            transition={{ duration: 0.18, ease: "easeOut" }}
            className="ml-4 overflow-hidden border-l border-[var(--border-subtle)] pl-5"
          >
            {" "}
            {group.docs.map((slug) => {
              const doc = docsMap.get(slug);
              if (!doc) {
                return null;
              }
              const isActive = activeSlug === doc.slug;
              return (
                <li key={doc.slug} className="mt-1.5">
                  {" "}
                  <button
                    onClick={() => onOpenDoc(doc.slug)}
                    className={`relative block w-full rounded-md px-3 py-2 text-left transition-colors ${isActive ? "bg-[var(--accent-bg)] font-semibold text-[var(--text-strong)]" : "text-[var(--text-main)] hover:bg-[var(--bg-hover)] hover:text-[var(--text-strong)]"}`}
                    type="button"
                  >
                    {" "}
                    {doc.title}{" "}
                  </button>{" "}
                </li>
              );
            })}{" "}
          </motion.ul>
        ) : null}{" "}
      </AnimatePresence>{" "}
    </li>
  );
}
function DocPagerCard({
  direction,
  doc,
  groupMap,
  onOpenDoc,
}: {
  direction: "prev" | "next";
  doc?: DocManifest;
  groupMap: Map<string, DocGroup>;
  onOpenDoc: (slug: string, sectionId?: string, replace?: boolean) => void;
}) {
  if (!doc) {
    return <div />;
  }
  const isPrev = direction === "prev";
  return (
    <button
      onClick={() => onOpenDoc(doc.slug)}
      className={`group flex min-h-[72px] flex-col justify-center gap-1 bg-transparent p-0 text-left transition-colors hover:text-[var(--accent)] ${isPrev ? "items-start" : "items-start md:items-end md:text-right"}`}
      type="button"
    >
      {" "}
      <div className="flex items-center gap-2 text-xs uppercase tracking-wide text-[var(--text-muted)]">
        {" "}
        {isPrev ? (
          <ArrowLeft className="h-4 w-4" />
        ) : (
          <ArrowRight className="h-4 w-4" />
        )}{" "}
        {isPrev ? "Previous" : "Next"}{" "}
      </div>{" "}
      <div>
        {" "}
        <div className="mb-1 text-sm text-[var(--text-muted)]">
          {groupMap.get(doc.groupId)?.title ?? doc.groupId}
        </div>{" "}
        <div className="font-semibold text-[var(--text-strong)] transition-colors group-hover:text-[var(--accent)]">
          {doc.title}
        </div>{" "}
      </div>{" "}
    </button>
  );
}
