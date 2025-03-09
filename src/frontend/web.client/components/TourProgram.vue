<script setup lang="ts">
import type { TourProgramType } from "~/types/TourProgramType";
const props = defineProps({
  program: {
    type: Array as PropType<TourProgramType[]>,
    default: () => [],
    required: true,
  },
});
const currentDay = ref<TourProgramType>(props.program[0]);

const selectDay = (day:TourProgramType) => {
  currentDay.value = day;
};
</script>

<template>
  <section class="tour-program section">
    <div class="main-container max-width">
        <!-- Навигация по дням -->
        <div class="days-navigation">
          <button
            v-for="day in program"
            :key="day.day"
            :class="['day-button', { active: currentDay.day === day.day }]"
            @click="selectDay(day)"
          >
            День {{ day.day }}
          </button>
        </div>

        <!-- Контент выбранного дня -->
        <div class="day-content">
          <div class="image-container">
            <img
              :src="currentDay.image"
              :alt="'День ' + currentDay.day"
              class="day-image"
            />
          </div>
          <div class="day-title">
            {{ 'День ' + currentDay.day + ': ' + currentDay.name }}
          </div>
          <div class="day-description">
            {{ currentDay.description }}
          </div>
        </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/tourProgram.scss" as *;
</style>
