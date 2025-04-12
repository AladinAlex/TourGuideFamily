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
      <h1 class="sendresult-title title">
        Ваша заявка отправлена!
      </h1>
      <h2 class="sendresult-description">
        Мы свяжемся с вами в ближайшее время.
      </h2>
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

    .sendresult
    {
      // &-title {}

      &-description {
        font-size: 30px;
        font-weight: 500;
        color: $text_title;
        margin: 30px 0;

        @media (max-width: 1024px) {
          font-size: 26px; // Для планшетов
        }

        @media (max-width: 768px) {
          font-size: 24px; // Для маленьких планшетов
        }

        @media (max-width: 480px) {
          font-size: 22px; // Для мобильных устройств
        }
      }
    }

  }
}
</style>
