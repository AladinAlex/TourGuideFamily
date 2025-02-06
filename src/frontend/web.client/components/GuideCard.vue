<script setup lang="ts">
import type { GuideType } from "~/types/GuideType";
const props = defineProps<GuideType>();
</script>

<template>
  <div class="guideCard">
    <div class="guideCard_left">
      <img class="guideCard__left-image" src="@/assets/images/unknownGuide.jpg" alt="Фото гида" />
    </div>
    <div class="guideCard__right">
      <div class="guideCard__right-content">
        <h1 class="guideCard__right-content-title title">
          {{ props.firstname + " " + props.surname }}
        </h1>
        <h2 class="guideCard__right-content-description">
          {{ props.description }}
        </h2>
        <div class="guideCard__right-content-text">
          <span class="text">{{ props.text }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/GuideCard.scss" as *;
</style>
