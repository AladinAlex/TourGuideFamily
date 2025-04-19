<script setup lang="ts">
import { useRoute } from "vue-router";
import Modal from "@/components/Modal.vue";
import EarlyBookingModal from "~/components/Modals/EarlyBookingModal.vue";
import { useModalStore } from "@/stores/modal";

const route = useRoute();
const layout = ref();

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
  openEarlyBookingModal()
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
