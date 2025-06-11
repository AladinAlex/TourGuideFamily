
import { fileURLToPath } from 'node:url'

export default defineNuxtConfig({
  ssr: true,
  app: {
    head: {
      link: [
        { rel: 'icon', type: 'image/png', href: '/favicon-96x96.png', sizes: '96x96' },
        { rel: 'icon', type: 'image/svg+xml', href: '/favicon.svg' },
        { rel: 'shortcut icon', href: '/favicon.ico' },
        { rel: 'apple-touch-icon', href: '/apple-touch-icon.png', sizes: '180x180' },
        { rel: 'manifest', href: '/site.webmanifest' },
      ]
    }
  },
  // nitro: {
  //   routeRules: {
  //     api:{
  //       ssr: true,        
  //       proxy: process.env.API_BASE_URL
  //     }
  //   }
  // },
  runtimeConfig: {
    public: {
      apiBase: process.env.API_BASE_URL ?? 'https://api.kam-brusnika.ru',
      recaptchaSecretKey: process.env.APP_RECAPTCHA_SECRET_KEY ?? '',
      recaptchaSiteKey: process.env.APP_RECAPTCHA_SITE_KEY ?? ''
    }
  },
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
    assetsInclude: ['/assets/**']
  }
})