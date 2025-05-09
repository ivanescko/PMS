import path from "path";

import react from "@vitejs/plugin-react";
import { visualizer } from "rollup-plugin-visualizer";
import { defineConfig } from "vite";
import svgr from "vite-plugin-svgr";

export default defineConfig({
    plugins: [
        react(),
        svgr(),
        visualizer({
            open: true,
            filename: "stats.html",
            gzipSize: true,
            brotliSize: true,
        }),
    ],
    publicDir: "public",
    build: {
        outDir: "build",
        assetsDir: "assets",
        rollupOptions: {
            output: {
                assetFileNames: (assetInfo) => {
                    if (
                        assetInfo.names.some((name) =>
                            name.match(/\.(woff2?|eot|ttf|otf)$/),
                        )
                    ) {
                        return "fonts/[name][extname]";
                    }

                    return "assets/[name][extname]";
                },
            },
        },
    },
    resolve: {
        alias: {
            "@app": path.resolve(__dirname, "./src/app"),
            "@pages": path.resolve(__dirname, "./src/pages"),
            "@widgets": path.resolve(__dirname, "./src/widgets"),
            "@features": path.resolve(__dirname, "./src/features"),
            "@entities": path.resolve(__dirname, "./src/entities"),
            "@shared": path.resolve(__dirname, "./src/shared"),
        },
        extensions: [".js", ".ts", ".jsx", ".tsx", ".json"],
    },
    server: {
        port: 3000,
        proxy: {
            "/api": {
                target: "http://localhost:8080", // URL бэкенда
                changeOrigin: true,
                secure: false,
            },
        },
    },
    preview: {
        port: 3000,
    },
});
