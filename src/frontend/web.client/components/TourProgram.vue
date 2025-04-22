<script setup lang="ts">
import { Swiper, SwiperSlide } from 'swiper/vue';
import { FreeMode, Navigation, Thumbs } from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/free-mode';
import 'swiper/css/navigation';
import 'swiper/css/thumbs';

import type { DayType } from "~/types/DayType";

const props = defineProps({
  days: {
    type: Array as PropType<DayType[]>,
    default: () => [],
    required: false,
  },
});

const thumbsSwiper = ref(null);
const modules = [FreeMode, Navigation, Thumbs];

const setThumbsSwiper = (swiper: any) => {
  thumbsSwiper.value = swiper;
};
</script>

<template>
  <section class="tour-program section">
    <swiper v-if="days.length > 1"
      @swiper="setThumbsSwiper"
      :spaceBetween="10"
      :slidesPerView="4"
      :freeMode="true"
      :watchSlidesProgress="true"
      :modules="modules"
      class="days-navigation max-width"
    >
      <swiper-slide v-for="day in days" :key="day.number">
        <span class="day-button" tabindex="1">День {{ day.number }}</span>
      </swiper-slide>
    </swiper>
    <swiper
      :effect="'fade'"
      :spaceBetween="10"
      :thumbs="{ swiper: thumbsSwiper }"
      :modules="modules"
      class="max-width mySwiper"
    >
      <swiper-slide v-for="day in days" :key="day.number">
        <div class="day-content">
          <div class="image-container">
            <img
              :src="day.image"
              :alt="'День ' + day.number"
              class="day-image"
            />
          </div>
          <div class="day-title" v-if="days.length > 1">
            {{ 'День ' + day.number + ': ' + day.name }}
          </div>
          <div class="day-description">
            {{ day.description }}
          </div>
        </div>
      </swiper-slide>
    </swiper>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/tourProgram.scss" as *;
</style>
