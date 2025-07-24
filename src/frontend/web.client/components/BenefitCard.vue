<script setup lang="ts">
import type { BenefitType } from "~/types/BenefitType";
const props = defineProps<BenefitType>();
</script>

<template>
    <div class="benefit-card" data-aos="fade-up">
        <img class="benefit-card__image" :src="image" alt=""/>
        <p class="benefit-card__title">{{ name }}</p>
    </div>
</template>

<style scoped lang="scss">
@use "./assets/css/benefitCard.scss" as *;
</style>
