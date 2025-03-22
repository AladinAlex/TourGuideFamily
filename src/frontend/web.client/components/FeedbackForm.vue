<script setup lang="ts">
import type { FeedbackType } from "~/types/FeedbackType";
import { useModalStore } from "@/stores/modal";


const props = defineProps({
  tourId: {
    type: Number,
    required: false,
    default: () => undefined,
  },
});

const { contactOptions } = useContactOptions();
let feedback = ref<FeedbackType>({
  firstname: "",
  phone: "",
  contactMethod: contactOptions[0].id,
  tourId: props.tourId,
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

const modal = useModalStore();
const privacyHandle = () => {
  modal.close()
}
</script>

<template>
  <div class="feedback-form section">
    <div class="main-container max-width">
      <h1 class="feedback-form__title title">
        Оставьте заявку и мы свяжемся с Вами
      </h1>
      <form class="feedback-form__form">
        <input
          type="text"
          :model="feedback.firstname"
          placeholder="Имя *"
          required
          class="feedback-form__form-inputname"
        />
        <input
          type="tel"
          v:odel="feedback.phone"
          placeholder="Номер телефона *"
          required
          class="feedback-form__form-inputphone"
        />
        <select
          :model="feedback.contactMethod"
          class="feedback-form__form-selecttype"
          placeholder="Выберите способ связи *"
          required
        >
          <option
            v-for="(option, key) in contactOptions"
            :key="key"
            :value="option.id"
          >
            {{ option.value }}
          </option>
        </select>
        <button
          type="submit"
          class="feedback-form__form-btn btn--size--bg"
          @click="sendClick"
        >
          Отправить
        </button>
        <span class="feedback-form__form-privacy">
          Нажимая кнопку, вы соглашаетесь с
          <NuxtLink to="/PrivacyPolicy" class="feedback-form__form-privacy-link" @click="privacyHandle">Политикой конфиденциальности</NuxtLink>
        </span>
      </form>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/feedbackForm.scss" as *;
</style>
