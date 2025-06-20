<script setup lang="ts">
import { useRoute } from "vue-router";
import Modal from "@/components/Modal.vue";
import EarlyBookingModal from "~/components/Modals/EarlyBookingModal.vue";
import { useModalStore } from "@/stores/modal";

const route = useRoute();
const layout = ref();
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
  ]
  // ,
  // script: [
  //   {
  //     src: `https://www.google.com/recaptcha/api.js?render=${config.public.recaptchaSiteKey}`,
  //     defer: true
  //   }
  // ]
})


watch(
  () => route.meta,
  async (newMeta, oldMeta) => {
    if (
      newMeta?.layout === undefined ||
      (newMeta?.layout || "default") !== (oldMeta?.layout || "default")
    ) {
      layout.value = markRaw(
        defineAsyncComponent(
          () => import(`@/layout/${newMeta?.layout || "default"}.vue`)
        )
      );
    }
  },
  { immediate: true }
);

const openEarlyBookingModal = () => {
  setTimeout(() => {
    if(!modal.state.component) {
      modal.open({
        component: EarlyBookingModal,
        componentProps: {}
      })
    } else {
      openEarlyBookingModal()
    }
  }, 5000);
}

const modal = useModalStore();
onMounted(() => {
  // openEarlyBookingModal()
});

</script>

<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
  <Modal />
</template>

<style lang="scss">
@use "@/assets/css/main.scss";
</style>
