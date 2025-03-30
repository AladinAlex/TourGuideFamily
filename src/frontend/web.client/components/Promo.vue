<script setup lang="ts">
import PromoCard from "~/components/PromoCard.vue";
import type { PromoType } from "~/types/PromoType";

const props = defineProps({
  promos: {
    type: Array as PropType<PromoType[]>,
    default: () => [],
    required: true,
  },
  title: {
    type: String,
    required: false
  }
});


</script>

<template>
  <section class="promo section">
    <div class="main-container max-width">
      <h1 class="promo__header title" v-if="title && title.length">{{ title }}</h1>
      <div class="promo__wrapper">
        <PromoCard
          v-for="(promo, index) in promos"
          :key="index"
          :image="promo.image"
          :name="promo.name"
          :description="promo.description"
        />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/promo.scss" as *;
</style>
