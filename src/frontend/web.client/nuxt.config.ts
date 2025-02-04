// https://nuxt.com/docs/api/configuration/nuxt-config
import { fileURLToPath } from 'url'

export default defineNuxtConfig({
  devtools: { enabled: true },
  compatibilityDate: "2025-02-04",
  modules: [
    '@nuxt/image',
  ],
  vite: {
    css: {
      preprocessorOptions: {
        scss: {
          additionalData: '@use "@/assets/css/main.css" as *;',
        },
      },
    },
    resolve: {
      alias: {
        '@': fileURLToPath(new URL('./', import.meta.url)), // Абсолютный путь к корню проекта
      },
    },
  },
})