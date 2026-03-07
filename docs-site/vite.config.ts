import tailwindcss from "@tailwindcss/vite";
import react from "@vitejs/plugin-react";
import path from "path";
import { defineConfig } from "vite";

export default defineConfig(() => {
  const repositoryName = process.env.GITHUB_REPOSITORY?.split("/")[1] ?? "";
  const base =
    process.env.VITE_BASE_PATH ||
    (process.env.GITHUB_ACTIONS === "true" && repositoryName
      ? `/${repositoryName}/`
      : "/");

  return {
    base,
    plugins: [react(), tailwindcss()],
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
