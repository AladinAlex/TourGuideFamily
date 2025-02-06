<script setup lang="ts">
import PromoCard from "~/components/PromoCard.vue";
import type { PromoType } from "~/types/PromoType";
let promos = ref<PromoType[]>([
  {
    image: "",
    title: "От четырех человек",
    description: "Семье или компании скидка - 5% на каждого",
  },
  {
    image: "",
    title: "От восьми человек",
    description: "Для больших компаний скидка - 10% на каждого",
  },
  {
    image: "",
    title: "День рождения",
    description:
      "Подарим скидку 5%, если ваш День Рождения выпадает на время похода",
  },
  {
    image: "",
    title: "Для детей",
    description: "Детям до 12 лет скидка 5%",
  },
  {
    image: "",
    title: "По совету друга",
    description: "Если Вы по совету от нашего клиента, то скидка - 5%",
  },
]);
</script>

<template>
  <div class="promo section">
    <div class="main-container max-width">
      <h1 class="promo__header title">Акции и скидки</h1>
      <div class="promo__wrapper">
        <PromoCard
          v-for="(promo, index) in promos"
          :key="index"
          :image="promo.image"
          :title="promo.title"
          :description="promo.description"
        />
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/promo.scss" as *;
</style>
