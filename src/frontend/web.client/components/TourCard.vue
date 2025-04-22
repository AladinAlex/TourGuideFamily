<script setup lang="ts">
import type { CardTourType } from "~/types/CardTourType";
import { useRouter } from 'vue-router';
const props = defineProps<CardTourType>();

const router = useRouter();
const routeToTour = (slug: string) => {
  var link = getTourRoute(slug)
  router.push(link);
}

const duration = () => {
  return getDuration(props.durationHourMin, props.durationHourMax, props.dayCount)
}

</script>

<template>
  <div class="tour-card" @click.self="routeToTour(props.slug)">
    <div class="tour-card__image-block">
      <img :src="image" class="tour-card__image" />
    </div>
    <div class="tour-card__content">
      <!-- TODO: переделать, добавить иконки (1 день или несколько, также для времени, лучше добрать икноку часов и дальше 8ч) -->
      <h3 class="title tour-card__title">{{ props.name }}</h3>
      <p class="tour-card__description description">
        <img
            src="@/assets/images/people.png"
            class="tour-card__description-image"
            alt="Группа людей"
          />
        <span class="tour-card__description-text">
          {{ props.minParticipants + " - " + props.maxParticipants }} чел.
        </span>
        <img
            src="@/assets/images/time_black.png"
            class="tour-card__description-image"
            alt="Длительность"
          />
        <span class="tour-card__description-text">
          {{ duration() }}
        </span>
      </p>
      <p class="tour-card__price">
        <img
            src="@/assets/images/ruble-black.png"
            class="tour-card__price-image"
            alt="Рубль"
          />
        <span class="tour-card__price-text">
          {{ formatPrice(props.price) }}
        </span>

      </p>
      <button class="tour-card__button btn" @click="routeToTour(props.slug)">Узнать больше</button>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/tourCard.scss" as *;
</style>
