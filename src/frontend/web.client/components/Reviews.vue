<script setup lang="ts">
import ReviewCard from "~/components/ReviewCard.vue";
import type { ReviewType } from "~/types/ReviewType";

const props = defineProps({
  reviews: {
    type: Array as PropType<ReviewType[]>,
    default: () => [],
    required: true,
  },
});

let title = "Отзывы наших гостей";
</script>

<template>
  <section class="reviews section">
    <div class="main-container max-width">
      <h1 class="reviews__header title" v-if="title && title.length">{{ title }}</h1>
      <div class="reviews-grid">
        <ReviewCard
          v-for="(review, index) in reviews"
          :key="index"
          :firstname="review.firstname"
          :rating="review.rating"
          :tourName="review.tourName"
          :createdOn="review.createdOn"
          :description="review.description"
        />
      </div>

      <div class="reviews-actions">
        <a
          href="https://experience.tripster.ru/guide/858783/#reviews"
          target="_blank"
          class="btn-primary btn"
        >
          Все отзывы на Tripster
        </a>
        <!-- <button class="btn-secondary btn" id="add-review">Оставить отзыв</button> -->
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/reviews.scss" as *;
</style>
