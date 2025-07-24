<script setup lang="ts">
import type { GuideType } from "~/types/GuideType";
const props = defineProps<GuideType>();
</script>

<template>
  <div class="guideCard" data-aos="fade-up">
    <div class="guideCard_left">
      <img class="guideCard__left-image" :src="image" alt="Фото гида" />
    </div>
    <div class="guideCard__right">
      <div class="guideCard__right-content">
        <h1 class="guideCard__right-content-title">
          {{ props.firstname }}
        </h1>
        <h2 class="guideCard__right-content-description">
          {{ props.description }}
        </h2>
        <!-- <div class="guideCard__right-content-text">
          <span class="text">{{ props.text }}</span>
        </div> -->
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/GuideCard.scss" as *;
</style>
