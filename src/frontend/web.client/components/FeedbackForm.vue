<script setup lang="ts">
import type { FeedbackType } from "~/types/FeedbackType";
let feedback = ref<FeedbackType>({
  firstname: "",
  phone: "",
});

const sendClick = async () => {
  if (
    feedback.value.contactMethod &&
    feedback.value.firstname &&
    feedback.value.phone
  ) {
    console.log("Данные формы:", feedback);
    alert("Форма успешно отправлена!");
  }
};
</script>

<template>
  <div class="feedback-form section">
    <div class="main-container max-width">
      <h1 class="feedback-form__title">Оставьте заявку и мы свяжемся с Вами</h1>
      <form class="feedback-form__form">
        <input
          type="text"
          v-model="feedback.firstname"
          placeholder="Имя *"
          required
          class="feedback-form__form-inputname"
        />
        <input
          type="tel"
          v-model="feedback.phone"
          placeholder="Номер телефона *"
          required
          class="feedback-form__form-inputphone"
        />
        <select
          v-model="feedback.contactMethod"
          class="feedback-form__form-selecttype"
          placeholder="Выберите способ связи *"
          required
        >
          <option value="telegram">Написать в Telegram</option>
          <option value="whatsapp">Написать в WhatsApp</option>
          <option value="call">Позвонить</option>
        </select>
        <button
          type="submit"
          class="feedback-form__form-btn"
          @click="sendClick"
        >
          Отправить
        </button>
        <span class="feedback-form__form-privacy"
          >Нажимая кнопку, вы соглашаетесь с Политикой конфиденциальности</span
        >
      </form>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/FeedbackForm.scss" as *;
</style>
