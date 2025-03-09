<script setup lang="ts">
import TourCard from "~/components/TourCard.vue";
import type { CardTourType } from "~/types/CardTourType";
let tours = ref<CardTourType[]>([
  {
    id: 1,
    name: "Восхождение на вулкан Горелый",
    description: "Цена за группу до 4 чел.",
    image: "",
    price: 46000
  },
  {
    id: 1,
    name: "Поездка на горячие источники",
    description: "Цена за человека",
    image: "",
    price: 8000,
  },
  {
    id: 1,
    name: "Восхождение на вулкан Горелый",
    description: "Цена за группу до 4 чел.",
    image: "",
    price: 46000,
  },
  {
    id: 1,
    name: "Поездка на горячие источники",
    description: "Цена за человека",
    image: "",
    price: 8000,
  },
  {
    id: 1,
    name: "Восхождение на вулкан Горелый",
    description: "Цена за группу до 4 чел.",
    image: "",
    price: 46000,
  },
  {
    id: 1,
    name: "Поездка на горячие источники",
    description: "Цена за человека",
    image: "",
    price: 8000,
  },
  {
    id: 1,
    name: "Восхождение на вулкан Горелый",
    description: "Цена за группу до 4 чел.",
    image: "",
    price: 46000,
  },
  {
    id: 1,
    name: "Поездка на горячие источники",
    description: "Цена за человека",
    image: "",
    price: 8000,
  },
]);
</script>

<template>
  <section class="tours section">
    <div class="main-container max-width">
      <h1 class="title">Программы путешествий</h1>
      <div class="tours__wrapper">
        <TourCard
          v-for="(tour, index) in tours"
          :key="index"
          :id="tour.id"
          :name="tour.name"
          :image="tour.image"
          :price="tour.price"
          :description="tour.description"
        />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "@/assets/css/tours.scss" as *;
</style>
