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

  <!-- <div class="usp-card" data-aos="fade-up">
        <div class="usp-icon">
          <img src="/assets/icons/jeep.svg" alt="Джипы" width="48">
        </div>
        <h3>Собственный парк внедорожников</h3>
        <p>
          Только подготовленные Nissan Safari с кондиционером и треккинговым
          оборудованием
        </p>
      </div>

      <div class="usp-card" data-aos="fade-up" data-aos-delay="100">
        <div class="usp-icon">
          <img src="/assets/icons/shield.svg" alt="Безопасность" width="48">
        </div>
        <h3>Гиды с 10+ летним опытом</h3>
        <p>Местные эксперты, знающие каждый каньон и медвежью тропу</p>
      </div> -->
</template>

<style scoped lang="scss">
@use "./assets/css/uspCard.scss" as *;
</style>
