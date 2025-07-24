<script setup lang="ts">
import BenefitCard from "~/components/BenefitCard.vue";
import uspCard from "~/components/uspCard.vue";
import type { BenefitType } from "~/types/BenefitType";
import type { uspType } from "~/types/uspType";
import roadImage from "@/assets/images/road.png";
import trekkingpolesImage from "@/assets/images/trekkingpoles.png";
import permissionImage from "@/assets/images/permission.png";
import compassImage from "@/assets/images/compass.png";
import mountainImage from "@/assets/images/mountain.png";
import costImage from "@/assets/images/cost.png";
import suvImage from "@/assets/images/suv.png";
import friendsImage from "@/assets/images/friends.png";
import eatImage from "@/assets/images/eat.png";

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
  image: compassImage
  },
  {
    name: 'Только проверенные маршруты',
    description: 'Лично протестировали все локации за 12 лет работы с 700+ туристами',
    image: mountainImage
  },
  {
    name: 'Цены без посредников — дешевле от 20%',
    description: 'Платите только за тур, а не накрутки агентств',
    image: costImage
  },
  {
    name: 'Чистые Nissan Safari после каждого тура',
    description: 'Чистые и подготовленные Nissan Safari с кондиционером',
    image: suvImage
  },
  {
    name: 'Тур только для вашей группы',
    description: 'Никаких незнакомцев — только ваши эмоции',
    image: friendsImage
  },
  {
    name: 'Горячий ланч и вода — чтобы сил хватило на приключения!',
    description: '"Мы продумали каждую мелочь — вам остаётся только наслаждаться видами!',
    image: eatImage
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
