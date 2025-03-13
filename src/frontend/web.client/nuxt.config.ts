// https://nuxt.com/docs/api/configuration/nuxt-config
import { fileURLToPath } from 'node:url'

export default defineNuxtConfig({
  // plugins: [
  //   // '~/plugins/pinia.client.ts',
  // ],
  devtools: { enabled: true },
  compatibilityDate: "2025-02-04",
  modules: [
    '@nuxt/image',
    '@pinia/nuxt',
  ],
  vite: {
    css: {
      preprocessorOptions: {
        scss: {
          additionalData: '@use "@/assets/css/main.scss" as *;',
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