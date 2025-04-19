<script setup lang="ts">
import { useTopToursStore } from "@/stores/topTours";
var year = new Date().getFullYear();
var phones: string[] = ["+7 (924) 783-04-21", "+7 (900) 444-11-25"];
var whatsAppLink: string = "https://wa.me/79247830421";
var telegramLink: string = "https://t.me/+79247830421";

const store = useTopToursStore();
const { topLinks } = storeToRefs(store);
</script>

<template>
  <footer class="footer">
    <div class="main-container max-width footer__main-container-nav">
      <div class="footer__wrap-logo">
        <NuxtLink class="logo" to="/">
          <img
            class="logo__image"
            src="@/assets/images/logo-1.png"
            alt="Логотип"
          />
        </NuxtLink>
      </div>
      <div class="footer__wrap-nav">
        <div class="footer__nav">
          <span class="footer__title">Туры</span>
          <ul class="footer__nav-list list-reset">
            <!-- <li class="footer__nav-li">
              <NuxtLink to="/" class="footer__link">Все туры</NuxtLink>
            </li> -->
            <NuxtLink
              v-for="(tour, index) in topLinks"
              to=""
              class="footer__link"
            >
              <li class="footer__nav-li">
                {{ tour.name }}
              </li>
            </NuxtLink>
          </ul>
        </div>
        <div class="footer__nav">
          <span class="footer__title">Команда</span>
          <ul class="footer__nav-list list-reset">
            <li class="footer__nav-li">
              <NuxtLink to="/" class="footer__link">О нас</NuxtLink>
            </li>
            <li class="footer__nav-li">
              <NuxtLink to="/" class="footer__link">Команда</NuxtLink>
            </li>
            <li class="footer__nav-li">
              <NuxtLink to="/" class="footer__link">Отзывы</NuxtLink>
            </li>
          </ul>
        </div>
        <div class="footer__nav">
          <span class="footer__title">Полезное</span>
          <ul class="footer__nav-list list-reset">
            <li class="footer__nav-li">
              <NuxtLink to="/PrivacyPolicy" class="footer__link"
                >Политика конфиденциальности</NuxtLink
              >
            </li>
          </ul>
        </div>
        <div class="footer__nav">
          <span class="footer__title">Связаться</span>
          <ul class="footer__nav-list list-reset">
            <li class="footer__nav-li">
              <p v-for="(phone, index) in phones">
                <NuxtLink :to="'tel:' + phone" class="footer__text">
                  {{ phone }}
                </NuxtLink>
              </p>
            </li>
            <li class="footer__nav-li">
              <div class="footer__social-link">
                <NuxtLink :to="telegramLink" target="_blank">
                  <img
                    src="@/assets/images/telegram.png"
                    class="footer__social-link__image"
                  />
                </NuxtLink>
                <NuxtLink :to="whatsAppLink" target="_blank">
                  <img
                    src="@/assets/images/whatsapp.png"
                    class="footer__social-link__image"
                  />
                </NuxtLink>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="main-container max-width"></div>
  </footer>
</template>

<style scoped lang="scss">
@use "./assets/css/footer.scss" as *;
</style>
