<script setup lang="ts">
import type { FeedbackType } from "~/types/FeedbackType";
import { useModalStore } from "@/stores/modal";
import RequestSendedModal from "@/components/Modals/RequestSendedModal.vue";
const { $api } = useNuxtApp();

const props = defineProps({
  slug: {
    type: String,
    required: false,
    default: () => undefined,
  },
});

const { contactOptions } = useContactOptions();
let feedback = ref<FeedbackType>({
  firstname: "",
  phone: "",
  contactMethod: contactOptions[0].id,
  slug: props.slug,
});

const sendClick = async () => {
  if (
    feedback.value.contactMethod &&
    feedback.value.firstname &&
    feedback.value.phone
  ) {
    try {
      const response = await $api("/main/feedback", { 
        method: "POST",
        body: JSON.stringify(feedback.value),
        headers: {
          "Content-Type": "application/json",
        },
      });
      modal.open({
        component: RequestSendedModal,
        componentProps: {}
      })
    } catch (error: any) {
      console.error("Ошибка при отправке данных:", error.message);
      throw error;
    }
  }
};

const modal = useModalStore();
const privacyHandle = () => {
  modal.close();
};
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
          :model="feedback.phone"
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
          type="button"
          class="feedback-form__form-btn btn--size--bg"
          @click="sendClick"
        >
          Отправить
        </button>
        <span class="feedback-form__form-privacy">
          Нажимая кнопку, вы соглашаетесь с
          <NuxtLink
            to="/PrivacyPolicy"
            class="feedback-form__form-privacy-link"
            @click="privacyHandle"
            >Политикой конфиденциальности</NuxtLink
          >
        </span>
      </form>
    </div>
  </div>
</template>

<style scoped lang="scss">
@use "./assets/css/FeedbackForm.scss" as *;
</style>
