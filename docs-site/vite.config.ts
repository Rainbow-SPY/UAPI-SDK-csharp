import fs from "node:fs";
import path from "path";
import tailwindcss from "@tailwindcss/vite";
import react from "@vitejs/plugin-react";
import { defineConfig } from "vite";

function readBrowserTitle() {
  const configPath = path.resolve(__dirname, "content", "site.config.json");
  const siteConfig = JSON.parse(
    fs.readFileSync(configPath, "utf8").replace(/^\uFEFF/, ""),
  ) as { brand?: { name?: string; browserTitle?: string } };

  return siteConfig.brand?.browserTitle ?? siteConfig.brand?.name ?? "Docs";
}

function escapeHtml(value: string) {
  return value
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
}

function browserTitlePlugin(title: string) {
  return {
    name: "browser-title-from-config",
    transformIndexHtml(html: string) {
      return html.replace(
        /<title>.*?<\/title>/s,
        `<title>${escapeHtml(title)}</title>`,
      );
    },
  };
}

export default defineConfig(() => {
  const browserTitle = readBrowserTitle();
  const repositoryName = process.env.GITHUB_REPOSITORY?.split("/")[1] ?? "";
  const base =
    process.env.VITE_BASE_PATH ||
    (process.env.GITHUB_ACTIONS === "true" && repositoryName
      ? `/${repositoryName}/`
      : "/");

  return {
    base,
    plugins: [react(), tailwindcss(), browserTitlePlugin(browserTitle)],
    resolve: {
      alias: {
        "@": path.resolve(__dirname, "."),
      },
    },
    build: {
      rollupOptions: {
        output: {
          manualChunks: {
            react: ["react", "react-dom"],
            motion: ["motion/react"],
            icons: ["lucide-react"],
          },
        },
      },
    },
    server: {
      hmr: process.env.DISABLE_HMR !== "true",
    },
  };
});
