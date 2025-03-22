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
  <div class="tour-card" @click.self="routeToTour('1')">
    <div class="tour-card__image-block">
      <img src="@/assets/images/tourImage.jpg" class="tour-card__image" />
    </div>
    <div class="tour-card__content">
      <!-- TODO: переделать, добавить иконки (1 день или несколько, также для времени, лучше добрать икноку часов и дальше 8ч) -->
      <h3 class="title tour-card__title">{{ props.name }}</h3>
      <p class="tour-card__description description">
        <img
            src="@/assets/images/people.png"
            class="tour-card__description-image"
            alt="Рубль"
          />
        <span class="tour-card__description-text">
          {{ props.description }} чел.
        </span>
      </p>
      <p class="tour-card__price">
        <img
            src="@/assets/images/ruble2.png"
            class="tour-card__price-image"
            alt="Рубль"
          />
        <span class="tour-card__price-text">
          {{ formatPrice(props.price) }}
        </span>

      </p>
      <button class="tour-card__button btn" @click="routeToTour('1')">Узнать больше</button>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/tourCard.scss" as *;
</style>
