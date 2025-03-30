<script setup lang="ts">
import Presentation from "~/components/Presentation.vue";
import AboutUs from "~/components/AboutUs.vue";
import Tours from "~/components/Tours.vue";
import Promo from "~/components/Promo.vue";
import FeedbackForm from "~/components/FeedbackForm.vue";
import type { MainType } from "~/types/MainType";
const { $api } = useNuxtApp()

definePageMeta({
  title: "Туры по Камчатке",
  layout: "default"
});

const model = ref<MainType | null>()
// const runtimeConfig = useRuntimeConfig();
// onServerPrefetch(async () => {
//   try {
//     const response = await $fetch<MainType>('main/main')
//     console.log('response: ', response)
//     model.value = response
//   } catch (error) {
//     console.log('error: ', error)
//   }
// });

const loadMainData = async () => {
  try {
    const {data: responseData, error: responseError} = await useAsyncData<MainType>('main', () => $api<MainType>('/main/main'))
    console.log('responseError', responseError.value)
    console.log('responseData', responseData.value)
    if(responseError.value) {
      console.log('error: ', responseError.value)
    } else {
      model.value = responseData.value
    }
  }
  catch(error)
  {
    console.log('error', error)
  }
}

await loadMainData()

</script>

<template>
  <main class="page">
    <div class="main-page">
      <Presentation />
      <AboutUs :guides="model?.guides" />
      <Tours :tours="model?.tours" />
      <Promo :promos="model?.promos" title="Акции и скидки" />
      <FeedbackForm />
    </div>
  </main>
</template>
