<script setup lang="ts">
import { useRoute } from "vue-router";
import Modal from "@/components/Modal.vue";

const route = useRoute();
const layout = ref();

watch(
  () => route.meta,
  async (newMeta, oldMeta) => {
    console.log("old", oldMeta);
    console.log("new", newMeta);
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
