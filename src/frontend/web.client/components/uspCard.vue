<script setup lang="ts">
import type { uspType } from "~/types/uspType";
const props = defineProps<uspType>();

</script>

<template>
  <div class="usp-card" data-aos="fade-up">
    <div class="usp-icon">
      <img :src="image" alt="усп"/>
    </div>
    <h3>{{ name }}</h3>
    <p>{{ description }}</p>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/uspCard.scss" as *;
</style>
