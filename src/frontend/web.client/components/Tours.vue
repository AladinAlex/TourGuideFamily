<script setup lang="ts">
import TourCard from "~/components/TourCard.vue";
import type { CardTourType } from "~/types/CardTourType";

const props = defineProps({
  tours: {
    type: Array as PropType<CardTourType[]>,
    default: () => [],
    required: true,
  }
});

</script>

<template>
  <section class="tours section">
    <div class="main-container max-width">
      <h1 class="title">Программы путешествий</h1>
      <div class="tours__wrapper">
        <TourCard
          v-for="(tour, index) in tours"
          :key="index"
          :image="tour.image"
          :name="tour.name"
          :min-participants="tour.minParticipants"
          :max-participants="tour.maxParticipants"
          :price="tour.price"
          :duration-hour-min="tour.durationHourMin"
          :duration-hour-max="tour.durationHourMax"
          :day-count="tour.dayCount"
          :slug="tour.slug"
        />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "@/assets/css/tours.scss" as *;
</style>
