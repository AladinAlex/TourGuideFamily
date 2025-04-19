<script setup lang="ts">
import TourProgram from "~/components/TourProgram.vue";
import PresentationTour from "~/components/PresentationTour.vue";
import Promo from "~/components/Promo.vue";
import FeedbackForm from "~/components/FeedbackForm.vue";
import type { TourType } from "~/types/TourType";
import FeedbackModal from "@/components/Modals/FeedbackModal.vue";
import { useModalStore } from "@/stores/modal";
const { $api } = useNuxtApp();

definePageMeta({
  title: "Страница тура",
  layout: "default",
});
const config = useRuntimeConfig()
const route = useRoute();
// Получаем текущий маршрут
const slug = route.params.slug as string;
var buttonText = "Оставить заявку";
const tour = ref<TourType>();

// Получаем значение параметра из route.params
// const loadTourData = async () => {
try {
  // console.log('slug: ', slug)

  // // const {data: responseData, error: responseError} = await useAsyncData<TourType>('tour', () => $api<TourType>('api/Main/Tour/' + slug))
  //   const {data: responseData, error: responseError} = await useFetch('/api/Main/Tour/slug')
  // if(responseError.value) {
  //   console.log('error: ', responseError.value)
  // } else {
  //   if(responseData.value)
  //     tour.value = responseData.value
  //   else
  //     tour.value = {} as TourType
  // }

  const { data, error, status } = await useFetch<TourType>(
    "/api/Main/Tour/" + slug,
    {
      baseURL: config.apiBase,
      onRequestError({ error }) {
        console.error("Request error (" + slug + "): ", error);
      },
    }
  );
  if (error.value) {
    console.log("error: ", error.value);
  } else {
    if (data.value) tour.value = data.value;
    else tour.value = {} as TourType;
  }
} catch (error) {
  console.log("error", error);
}
// }

// await loadTourData()

const modal = useModalStore();
const handleClick = () => {
  modal.open({
    component: FeedbackModal,
    componentProps: {},
  });
};
</script>

<template>
  <div class="tour-page">
    <!-- Фоновое изображение -->
    <div
      class="background-image"
      :style="{ backgroundImage: `url(&quot;${tour?.image}&quot;)` }"
    >
      <div class="content-overlay">
        <h1 class="tour-title">{{ tour?.name }}</h1>

        <p class="tour-description">{{ tour?.description }}</p>

        <div class="tour-price">
          <img
            src="@/assets/images/ruble6.png"
            class="tour-price__image"
            alt="Рубль"
          />
          <span class="tour-price__text">{{
            formatPrice(tour?.price ?? 0)
          }}</span>
        </div>

        <div class="tour-duration">
          <img
            src="@/assets/images/time1.png"
            class="tour-duration__image"
            alt="Рубль"
          />
          <span class="tour-duration__text">
            {{ 1 + " " + addWordDay(1) }}</span
          >
        </div>

        <button class="tour-btn" @click="handleClick">{{ buttonText }}</button>
      </div>
    </div>
  </div>
  <TourProgram :days="tour?.days" />
  <PresentationTour
    :price="tour?.price"
    :included="tour?.included"
    :excluded="tour?.excluded"
  />
  <Promo :promos="tour?.promos" />
  <FeedbackForm :slug="slug" />
</template>

<style scoped lang="scss">
@use "./assets/css/tour.scss" as *;
</style>
