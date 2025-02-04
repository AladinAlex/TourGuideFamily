<script setup lang="ts">
import GuideCard from "~/components/GuideCard.vue";
import type { GuideType } from "~/types/GuideType";

let guides = ref<GuideType[]>([
  {
    firstname: "Александр",
    surname: "Аладинский",
    description: "Основатель, инструктор-проводник, гид",
    text: "Это он ответит вам, когда позвоните. Рулил автомобильным бизнесом, пока однажды на вершине Эльбруса не понял, что дело жизни выглядит совсем иначе. С тех пор прошёл вершины Кавказа, вулканы Камчатки, тысячники, перебрался на Марс, исследовал его и вернулся на Землю.",
    image: "@/assets/images/AlexandrGuide.jpg"
  },
  {
    firstname: "Марина",
    surname: "Аладинская",
    description: "Основатель, инструктор-проводник, гид",
    text: "Это он ответит вам, когда позвоните. Рулил автомобильным бизнесом, пока однажды на вершине Эльбруса не понял, что дело жизни выглядит совсем иначе. С тех пор прошёл вершины Кавказа, вулканы Камчатки, тысячники, перебрался на Марс, исследовал его и вернулся на Землю.",
    image: "@/assets/images/unknownGuide.jpg"
  },
]);
</script>

<template>
  <section class="about-us section">
    <div class="main-container max-width">
      <div class="about-us__header">
        <img
          class="about-us__header-image"
          src="@/assets/images/lingonberry.png"
          alt=""
        />
        <span class="about-us__header-text">Сайт гидов и экскурсоводов Александра и Марины Аладинских</span
        >
        <!-- <span class="about-us__header-text">Откройте для себя достопримечательности Камчатки вместе с нами!</span> -->
      </div>
      <div class="about-us__content">
        <GuideCard
          v-for="(guide, index) in guides"
          :key="index"
          :firstname="guide.firstname"
          :surname="guide.surname"
          :description="guide.description"
          :text="guide.text"
          :image="guide.image"
        />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/aboutUs.scss" as *;
</style>
