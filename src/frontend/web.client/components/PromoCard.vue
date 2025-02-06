<script setup lang="ts">
import type { PromoType } from "~/types/PromoType";
const props = defineProps<PromoType>();
</script>

<template>
    <div class="promo-card">
        <img class="promo-card__image" src="@/assets/images/discount.png" alt="" />
        <p class="promo-card__title">{{ title }}</p>
        <p class="promo-card__description description">{{ description }}</p>
    </div>
</template>

<style scoped lang="scss">
@use "./assets/css/promoCard.scss" as *;
</style>
