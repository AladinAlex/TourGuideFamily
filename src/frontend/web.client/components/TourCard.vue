<script setup lang="ts">
import type { CardTourType } from "~/types/CardTourType";
import { useRouter } from 'vue-router';
const props = defineProps<CardTourType>();

const router = useRouter();
const routeToTour = (id: string) => {
  router.push('/tours/' + 1);
}
</script>

<template>
  <div class="tour-card">
    <div class="tour-card__image-block">
      <img src="@/assets/images/tourImage.jpg" class="tour-card__image" />
    </div>
    <div class="tour-card__content">
      <!-- TODO: переделать, добавить иконки (1 день или несколько, также для времени, лучше добрать икноку часов и дальше 8ч) -->
      <h3 class="title tour-card__title">{{ props.name }}</h3>
      <p class="tour-card__description description">{{ props.description }}</p>
      <p class="tour-card__price">{{ formatPrice(props.price) }}</p>
      <button class="tour-card__button btn" @click="routeToTour('1')">Узнать больше</button>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/tourCard.scss" as *;
</style>
