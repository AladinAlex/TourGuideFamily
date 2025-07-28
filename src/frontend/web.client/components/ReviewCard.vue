<script setup lang="ts">
import { getStarRating } from "~/composables/functions";
import type { ReviewType } from "~/types/ReviewType";
import travelerImage from "@/assets/images/traveler.png";
const props = defineProps<ReviewType>();

const Rating = () => {
  return  getStarRating(props.rating, true)
}
const formatCreatedOnDate = () => {
  return formatDate(props.createdOn)
}
</script>

<template>
  <div class="review-card" data-aos="fade-up">
    <div class="review-card-header">
      <img :src="travelerImage" alt="Цитата" class="quote-icon">
      <div class="reviewer-info">
        <div class="stars">{{ Rating() }}</div>
        <span class="reviewer-name">{{ firstname }}</span>
        <span class="review-date">{{ formatCreatedOnDate() }}</span>
      </div>
    </div>
    <div class="review-content">
      <p>
        {{ description }}
      </p>
    </div>
    <div v-if="tourName" class="review-footer">
      <span class="trip-info">Тур: "{{ tourName }}"</span>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/reviewCard.scss" as *;
</style>
