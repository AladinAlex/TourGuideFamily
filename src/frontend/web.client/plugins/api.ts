import { $fetch } from 'ofetch';

export default defineNuxtPlugin((nuxtApp) => {
    const api = $fetch.create({
      baseURL: 'https://localhost:7276/api'
    })
    return {
      provide: {
        api
      }
    }
  })
  