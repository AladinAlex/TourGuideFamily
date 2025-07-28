<script setup lang="ts">
import ReviewCard from "~/components/ReviewCard.vue";
import type { ReviewType } from "~/types/ReviewType";
import { Swiper, SwiperSlide } from "swiper/vue";
import { FreeMode, Navigation } from "swiper/modules";
import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/navigation";
import { useModalStore } from "@/stores/modal";

const props = defineProps({
  reviews: {
    type: Array as PropType<ReviewType[]>,
    default: () => [],
    required: true,
  },
});

// const modal = useModalStore();
// const handleClick = () => {
//   modal.open({
//     component: FeedbackModal,
//     componentProps: {}
//   })
// };


let title = "Отзывы наших гостей";

const thumbsSwiper = ref(null);
const modules = [FreeMode, Navigation];
const setThumbsSwiper = (swiper: any) => {
  thumbsSwiper.value = swiper;
};

const slidesPerView = ref(2);
const swiperBreakpoints = {
  // Когда ширина >= 1200px
  1200: {
    slidesPerView: 3,
    spaceBetween: 30,
  },
  // Когда ширина >= 768px
  768: {
    slidesPerView: 2,
    spaceBetween: 20,
  },
  // Когда ширина < 768px
  0: {
    slidesPerView: 1,
    spaceBetween: 10,
  },
};
const paginationOptions = {
  clickable: true,
  bulletClass: "review-bullet",
  bulletActiveClass: "review-bullet-active",
};
onMounted(() => {
  const updateSlidesPerView = () => {
    if (window.innerWidth >= 1200) {
      slidesPerView.value = 3;
    } else if (window.innerWidth >= 768) {
      slidesPerView.value = 2;
    } else {
      slidesPerView.value = 1;
    }
  };

  updateSlidesPerView();
  window.addEventListener("resize", updateSlidesPerView);

  onBeforeUnmount(() => {
    window.removeEventListener("resize", updateSlidesPerView);
  });
});
</script>

<template>
  <section class="reviews section">
    <div class="main-container max-width">
      <h1 class="reviews__header title" v-if="title && title.length">
        {{ title }}
      </h1>
      <div class="reviews-slider-wrapper">
        <swiper
          :modules="modules"
          :slides-per-view="slidesPerView"
          :space-between="20"
          :pagination="paginationOptions"
          class="reviews-slider"
          :breakpoints="swiperBreakpoints"
        >
          <swiper-slide v-for="(review, index) in reviews" :key="index">
            <ReviewCard
              :firstname="review.firstname"
              :rating="review.rating"
              :tourName="review.tourName"
              :createdOn="review.createdOn"
              :description="review.description"
            />
          </swiper-slide>
        </swiper>
      </div>

      <div class="reviews-actions">
        <a
          href="https://experience.tripster.ru/guide/858783/#reviews"
          target="_blank"
          class="btn-primary btn"
        >
          Все отзывы на Tripster
        </a>
      <!-- <button class="btn-secondary btn" id="add-review" @click="handleClick">Оставить отзыв</button> -->
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/reviews.scss" as *;
</style>
