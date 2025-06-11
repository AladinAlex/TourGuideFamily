<script setup lang="ts">
import { useModalStore } from "@/stores/modal";
import TourProgram from "~/components/TourProgram.vue";
import PresentationTour from "~/components/PresentationTour.vue";
import Promo from "~/components/Promo.vue";
import FeedbackForm from "~/components/FeedbackForm.vue";
import FeedbackModal from "@/components/Modals/FeedbackModal.vue";

import type { TourType } from "~/types/TourType";

const { $api } = useNuxtApp()

definePageMeta({
  // title: "Страница тура",
  layout: "default",
});

const config = useRuntimeConfig()

const route = useRoute();
const slug = route.params.slug as string;
const buttonText = "Оставить заявку";
const tour = ref<TourType>()

try {
  const {
    data: responseData,
    error: responseError
  } = await useAsyncData<TourType>('tour', () => $api<TourType>('/Main/Tour/' + slug));
  // console.log('responseError', responseError.value);
  // console.log('responseData', responseData.value);

  if (responseError.value) {
    console.log('error: ', responseError.value)
  } else {
    if (responseData.value) {
      tour.value = responseData.value;

      useHead({
        title: () => tour.value?.name || "Страница тура"
      });
    } else {
      tour.value = {} as TourType;
    }
  }

  console.log('tour.value', tour.value);
} catch(error) {
  useHead({
    title: "Страница тура"
  });

  console.log('error', error);
}

const modal = useModalStore();
const handleClick = () => {
  modal.open({
    component: FeedbackModal,
    componentProps: {},
  });
};

const duration = () => {
  return getDuration(tour.value?.durationHourMin, tour.value?.durationHourMax, tour.value?.days.length)
}
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

        <!-- <p class="tour-description">{{ tour?.description }}</p> -->

        <div class="tour-price">
          <img
            src="@/assets/images/ruble6.png"
            class="tour-price__image"
            alt="Рубль"
          />
          <div>
            <span class="tour-price__text">{{
              formatPrice(tour?.price ?? 0)
            }}</span>
          <span class="tour-price__text2">за машину</span>
        </div>
        </div>

        <div class="tour-duration">
          <img
            src="@/assets/images/time1.png"
            class="tour-duration__image"
            alt="Рубль"
          />
          <span class="tour-duration__text">
            {{ duration() }}</span
          >
        </div>

        <button class="tour-btn" @click="handleClick">{{ buttonText }}</button>
      </div>
    </div>
  </div>
  <TourProgram :days="tour?.days" :description="tour?.description" :description-image="tour?.descriptionImage" />
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
