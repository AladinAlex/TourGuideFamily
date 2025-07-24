<script setup lang="ts">
import FeedbackModal from "@/components/Modals/FeedbackModal.vue";
import { useModalStore } from "@/stores/modal";

var title = "Джип-туры";
var description =
  "Мы проводим джип-туры по Камчатке. Вы увидите нетронутую цивилизацией природу – огнедышащие вулканы, высокие горы, термальные источники, бурные реки, прозрачные озера";
var description1 = "Особый подход к каждому гостю - наша визитная карточка. Мы организовываем для Вашей семьи (компании) индивидуальные экскурсии, создаем незабываемые путешествия, учитывая Ваши интересы и пожелания. Выбирая путешествие с нами, Вы погрузитесь в мир камчатской природы.";
var buttonText = "Заказать звонок";

const modal = useModalStore();
const handleClick = () => {
  modal.open({
    component: FeedbackModal,
    componentProps: {}
  })
};

</script>

<template>
  <div class="presentation">
    <div class="presentation__left">
      <img
        src="@/assets/images/presentation.jpeg"
        alt="Заставка"
        class="presentation__left-image"
      />
    </div>
    <div class="presentation__right">
      <div class="presentation__right-content">
        <h1 class="presentation__title">{{ title }}</h1>
        <p class="presentation__description">{{ description }}</p>
        <p class="presentation__description presentation__description__1">{{ description1 }}</p>
        <button class="button btn" @click="handleClick">
          {{ buttonText }}
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/presentation.scss" as *;
</style>
