<script setup lang="ts">
import { useModalStore } from "@/stores/modal";
import RequestSendedModal from "@/components/Modals/RequestSendedModal.vue";

import type { FeedbackType } from "~/types/FeedbackType";
import type { RecaptchaResponse } from "~/types/RecaptchaResponse";

const props = defineProps({
  slug: {
    type: String,
    required: false,
    default: () => undefined,
  },
});
const config = useRuntimeConfig();
const { contactOptions } = useContactOptions();
// const feedback = reactive<FeedbackType>({
//   firstname: '',
//   phone: '',
//   contactMethod: contactOptions[0].id,
//   slug: props.slug,
// });

const recaptchaSiteKey = config.public.recaptchaSiteKey
const recaptchaSecretKey = config.public.recaptchaSecretKey
const firstname = ref<string>("");
const phone = ref<string>("");
const slug = ref<string | undefined>("");
const contactMethod = ref<number>(contactOptions[0].id);

const mask = {
  mask: '{+7} (000) 000-00-00',
  lazy: true
};

const sendClick = async () => {
  // const grecaptcha = (window as any).grecaptcha;
  // const token = await grecaptcha.execute(recaptchaSiteKey, { action: 'submit' });
  // let isSuccessRecaptcha = false;

  // const { data, error } = await useFetch<RecaptchaResponse>('https://www.google.com/recaptcha/api/siteverify', {
  //   method: 'POST',
  //   body: {
  //     secret: recaptchaSecretKey,
  //     response: token,
  //     // remoteip
  //   }
  // })

  // if (data.value && data.value.success && data.value.score >= 0.5) {
  //   console.log('Рекапча пройдена');
  //   isSuccessRecaptcha = true;
  // } else {
  //   console.log('Рекапча не пройдена');
  // }

  let isSuccessRecaptcha = true
  if (contactMethod && firstname && phone && isSuccessRecaptcha) {
    let isOk = true
    try {
      const { data, error, status } = await useFetch("/api/main/feedback", {
        // baseURL: process.env.API_BASE_URL,
        baseURL: config.public.apiBase,
        method: "POST",
        body: JSON.stringify({
          firstname: firstname.value,
          phoneNumber: phone.value,
          contactMethod: contactMethod.value,
          slug: slug.value,
        }),
        headers: {
          "Content-Type": "application/json",
        },
        onRequestError({ error }) {
          isOk = false
          console.error("Request error:", error);
        },
      });
      if(isOk)
        modal.open({
          component: RequestSendedModal,
          componentProps: {},
        });
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
          v-model="firstname"
          placeholder="Имя *"
          required
          class="feedback-form__form-inputname"
          @change="() => console.log('Name changed:', firstname)"
        />
        <client-only>
          <input
            type="tel"
            v-model="phone"
            v-imask="mask"
            placeholder="Номер телефона *"
            required
            class="feedback-form__form-inputphone"
          />
        </client-only>
        <select
          v-model="contactMethod"
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
