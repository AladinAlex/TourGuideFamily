<script setup lang="ts">
import Presentation from "~/components/Presentation.vue";
import AboutUs from "~/components/AboutUs.vue";
import Tours from "~/components/Tours.vue";
import Promo from "~/components/Promo.vue";
import FeedbackForm from "~/components/FeedbackForm.vue";
import type { MainType } from "~/types/MainType";

const { $api } = useNuxtApp();
const config = useRuntimeConfig();

useHead({
  title: "Туры по Камчатке от Александра и Марины Аладинских",
  meta: [
    { name: 'description', content: 'Групповые и ндивидуальные туры по Камчатке с местными гидами. Восхождения на вулканы, термальные источники, смотровыеЮ местная культура. Лучшие цены 2025!' },
    { name: 'keywords', content: "туры на Камчатку, Камчатка 2025, вулканы Камчатки, тур к медведям, отдых на Камчатке цена, кам-брусника, кам брусника" },
    { name: 'og:title', content: 'Туры по Камчатке от Александра и Марины Аладинских' },
    { name: 'og:description', content: 'Групповые и ндивидуальные туры по Камчатке с лучшими гидами' },
    { name: 'og:image', content: '/og.jpg' },
    { property: 'og:type', content: 'website' },
  ],
})

const model = ref<MainType | null>();
// const route = useRoute();
// function scrollToBlock(blockId: string) {
//   nextTick(() => {
//     const element = document.getElementById(blockId);
//     if (element) {
//       element.scrollIntoView({ behavior: 'smooth' });
//     } else {
//       console.warn(`Block with id "${blockId}" not found.`);
//     }
//   });
// }

// onMounted(() => {
//   const blockId = route.query.scrollTo;
//   if (blockId && typeof blockId === 'string') {
//     scrollToBlock(blockId);
//   }
// });

// // onBeforeRouteUpdate((to) => {
// //   const blockId = to.query.scrollTo;
// //   if (typeof blockId === 'string') {
// //     scrollToBlock(blockId);
// //   }
// // });

// // Отслеживание изменений параметра scrollTo
// watch(
//   () => route.query.scrollTo,
//   (newBlockId) => {
//     if (newBlockId && typeof newBlockId === 'string') {
//       scrollToBlock(newBlockId);
//     }
//   { immediate: true }
// );

const loadMainData = async () => {
  try {
    // const { data: responseData, error: responseError } =
    //   await useAsyncData<MainType>("main", () => $api<MainType>("api/main/main"));
    // if (responseError.value) {
    //   console.log("error: ", responseError.value);
    // } else {
    //   model.value = responseData.value;
    // }
    const { data, error, status } = await useFetch<MainType>("/api/main/main", {
      baseURL: config.public.apiBase,
      onRequestError({ error }) {
        console.error("Request error (main):", error);
      },
    });

    if (error.value) {
      console.log("error: ", error.value);
    } else {
      model.value = data.value;
    }
  } catch (error) {
    console.log("error: ", error);
  }
};

await loadMainData();
</script>

<template>
  <main class="page">
    <div class="main-page">
      <Presentation />
      <AboutUs id="about" :guides="model?.guides" />
      <Tours id="tours" :tours="model?.tours" />
      <Promo id="promo" :promos="model?.promos" title="Акции и скидки" />
      <FeedbackForm />
    </div>
  </main>
</template>
