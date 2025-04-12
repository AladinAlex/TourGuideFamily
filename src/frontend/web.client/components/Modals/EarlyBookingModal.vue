<script setup lang="ts">
import FeedbackModal from "~/components/Modals/FeedbackModal.vue";
import { useModalStore } from "@/stores/modal";

defineEmits(["close"]);

const modal = useModalStore();

const handleClick = () => {
  modal.open({
    component: FeedbackModal,
    componentProps: {}
  })
}
</script>

<template>
  <div class="modal-content">
    <button @click="$emit('close')" class="close-button">&times;</button>
    <div class="section">
    <div class="main-container max-width">
      <h1 class="booking-title title">
        Скидки на раннее бронирование
      </h1>
      <p class="booking-description">
        Забронируйте тур до 30 мая и получите скидку 15%!
      </p>
      <button class="btn" @click="handleClick">Получить скидку</button>
    </div>
  </div>
  </div>
</template>

<style lang="scss">
@use "@/assets/css/global.scss" as *;

.modal-content {
  position: relative;
  margin: auto;
  padding: 20px;
  border-radius: 15px;

  .close-button {
    position: absolute;
    top: 26px;
    right: 26px;
    font-size: 36px;
    background: none;
    border: none;
    cursor: pointer;
  }

  .section {
    padding: 50px !important;
    border-radius: 15px;

    .booking
    {
      // &-title {}

      &-description {
        font-size: 24px;
        font-weight: 500;
        color: $text_title;
        margin: 30px 0;

        @media (max-width: 1024px) {
          font-size: 20px; // Для планшетов
        }

        @media (max-width: 768px) {
          font-size: 18px; // Для маленьких планшетов
        }

        @media (max-width: 480px) {
          font-size: 16px; // Для мобильных устройств
        }
      }
    }

  }
}
</style>
