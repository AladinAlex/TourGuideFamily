<script setup lang="ts">
import type { DayType } from "~/types/DayType";
const props = defineProps({
  days: {
    type: Array as PropType<DayType[]>,
    default: () => [],
    required: false,
  },
});
const currentDay = ref<DayType>(props.days[0]);

const selectDay = (day:DayType) => {
  currentDay.value = day;
};
</script>

<template>
  <section class="tour-program section">
    <div v-if="days?.length" class="main-container max-width">
        <!-- Навигация по дням -->
        <div class="days-navigation">
          <button
            v-for="day in days"
            :key="day.number"
            :class="['day-button', { active: currentDay.number === day.number }]"
            @click="selectDay(day)"
          >
            День {{ day.number }}
          </button>
        </div>

        <!-- Контент выбранного дня -->
        <div class="day-content">
          <div class="image-container">
            <img
              :src="currentDay.image"
              :alt="'День ' + currentDay.number"
              class="day-image"
            />
          </div>
          <div class="day-title">
            {{ 'День ' + currentDay.number + ': ' + currentDay.name }}
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
