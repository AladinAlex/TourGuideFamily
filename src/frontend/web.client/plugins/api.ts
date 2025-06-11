import { $fetch } from 'ofetch';

export default defineNuxtPlugin((nuxtApp) => {
    const api = $fetch.create({
      baseURL: 'https://api.kam-brusnika.ru/api'
    })
    return {
      provide: {
        api
      }
    }
  })
  