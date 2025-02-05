<script setup lang="ts">
import type { TourType } from "~/types/TourType";
const props = defineProps<TourType>();

// function addWordDay(value: number): string {
//   const lastDigit = value % 10;
//   const lastTwoDigits = value % 100;
//   if (lastDigit === 1 && lastTwoDigits !== 11) {
//     return "день";
//   } else if (
//     lastDigit >= 2 &&
//     lastDigit <= 4 &&
//     !(lastTwoDigits >= 12 && lastTwoDigits <= 14)
//   ) {
//     return "дня";
//   } else {
//     return "дней";
//   }
// }
const formattedPrice = computed(() => {
  return new Intl.NumberFormat('ru-RU').format(props.price);
});
</script>

<template>
  <div class="tour-card">
    <div class="tour-card__image-block">
      <img src="@/assets/images/tourImage.jpg" class="tour-card__image" />
    </div>
    <div class="tour-card__content">
      <h3 class="tour-card__title">{{ props.name }}</h3>
      <p class="tour-card__description">{{ props.description }}</p>
      <p class="tour-card__price">{{ formattedPrice }}</p>
      <button class="tour-card__button">Узнать больше</button>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/tourCard.scss" as *;
</style>
