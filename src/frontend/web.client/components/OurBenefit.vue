<script setup lang="ts">
import BenefitCard from "~/components/BenefitCard.vue";
import uspCard from "~/components/uspCard.vue";
import type { BenefitType } from "~/types/BenefitType";
import type { uspType } from "~/types/uspType";
import roadImage from "@/assets/images/road.png";
import lunchImage from "@/assets/images/lunch.png";
import waterImage from "@/assets/images/water.png";
import trekkingpolesImage from "@/assets/images/trekkingpoles.png";
import permissionImage from "@/assets/images/permission.png";
import jeepImage from "@/assets/images/jeep.png";

const props = defineProps({
  title: {
    type: String,
    required: false,
  }
});

var benefits: BenefitType[] = [
  {
    name: "Трансфер от места проживания и обратно",
    image: roadImage,
  },
  {
    name: "Треккинговые палки",
    image: trekkingpolesImage,
  },
  {
    name: "Все необходимые разрешения в природные парки",
    image: permissionImage,
  },
  // {
  //   name: "Ланч",
  //   image: lunchImage,
  // },
  // {
  //   name: "Питьевая бутилированная вода",
  //   image: waterImage,
  // },
  // {
  //   name: "Экскурсии проводятся на подготовленных внедорожниках Nissan Safari",
  //   image: jeepImage,
  // },
];

var usps: uspType[] =[
  {
  name: 'Местные гиды с 10+ летним опытом',
  description: 'Знаем каждую тропу, куда не водят массовые группы',
  image: '/_nuxt/assets/images/compass.png'
  },
  {
    name: 'Только проверенные маршруты',
    description: 'Лично протестировали все локации за 12 лет работы с 700+ туристами',
    image: '/_nuxt/assets/images/mountain.png'
  },
  {
    name: 'Цены без посредников — дешевле от 20%',
    description: 'Платите только за тур, а не накрутки агентств',
    image: '/_nuxt/assets/images/cost.png'
  },
  {
    name: 'Чистые Nissan Safari после каждого тура',
    description: 'Чистые и подготовленные Nissan Safari с кондиционером',
    image: '/_nuxt/assets/images/suv.png'
  },
  {
    name: 'Тур только для вашей группы',
    description: 'Никаких незнакомцев — только ваши эмоции',
    image: '/_nuxt/assets/images/friends.png'
  },
  {
    name: 'Горячий ланч и вода — чтобы сил хватило на приключения!',
    description: '"Мы продумали каждую мелочь — вам остаётся только наслаждаться видами!',
    image: '/_nuxt/assets/images/eat.png'
  },
]
</script>

<template>
  <section class="benefit section">
    <div class="main-container max-width">
      <!-- <h1 class="benefit__header title" v-if="title && title.length">
        {{ title }}
      </h1> -->
      <div class="benefit__wrapper">
        <BenefitCard
          v-for="(promo, index) in benefits"
          :key="index"
          :image="promo.image"
          :name="promo.name"
        />
      </div>
      <div class="usp-grid">
          <uspCard
            v-for="(promo, index) in usps"
            :key="index"
            :image="promo.image"
            :name="promo.name"
            :description="promo.description"
          />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/ourBenefits.scss" as *;

.usp-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 30px;
}


</style>
