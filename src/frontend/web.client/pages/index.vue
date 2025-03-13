<script setup lang="ts">
import Presentation from "~/components/Presentation.vue";
import AboutUs from "~/components/AboutUs.vue";
import Tours from "~/components/Tours.vue";
import Promo from "~/components/Promo.vue";
import FeedbackForm from "~/components/FeedbackForm.vue";
import type { PromoType } from "~/types/PromoType";

definePageMeta({
  title: "Туры по Камчатке",
  layout: "default"
});

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
  <main class="page">
    <div class="main-page">
      <Presentation />
      <AboutUs />
      <Tours />
      <Promo :promos="promos" title="Акции и скидки" />
      <FeedbackForm />
    </div>
  </main>
</template>
