<script setup lang="ts">
import { useRoute } from 'vue-router';
import InProgressModal from "~/components/Modals/InProgressModal.vue";
import { useModalStore } from "@/stores/modal";

const route = useRoute();
const modal = useModalStore();

const isMenuOpen = ref<boolean>(false);

const toggleMenu = (): void => {
  isMenuOpen.value = !isMenuOpen.value;
};

const handleClick = (): void => {
  isMenuOpen.value = false;
  modal.open({
    component: InProgressModal,
    componentProps: {}
  })
};

watch(
  () => route,
  (value): void => {
    if (value.hash) {
      isMenuOpen.value = false;
    }
  },
  { deep: true }
);
</script>

<template>
  <header class="header">
    <div class="header__container-logo">
      <NuxtLink to="/" class="logo">
        <img
          src="@/assets/images/logo-1.png"
          alt="Логотип"
          class="logo__image"
        />
      </NuxtLink>
      <div>
        <div>
          <span class="logo-text">KAM-BRUSNIKA</span>
        </div>
        <div>
          <span class="logo-text2">By Aladinsky Family</span>
        </div>
      </div>
    </div>
    <div class="header__menu">
      <button class="header__mobile-menu" @click="toggleMenu">☰</button>
      <nav class="header__nav" :class="{ 'header__nav--active': isMenuOpen }">
        <ul class="header__nav-ul list-reset">
          <li class="header__nav-li">
            <!-- <a class="header__nav-link" href="#tours">Туры</a> -->
            <NuxtLink class="header__nav-link" to="/#tours">Туры</NuxtLink>
          </li>
          <li class="header__nav-li">
            <!-- <a class="header__nav-link" href="#about">Наша команда</a> -->
            <NuxtLink class="header__nav-link" to="/#about">Наша команда</NuxtLink>
          </li>
          <!-- <li class="header__nav-li"> -->
            <!-- <a class="header__nav-link" href="#reviews">Контакты</a> -->
            <!-- <NuxtLink class="header__nav-link" @click="handleClick">Контакты</NuxtLink> -->
          <!-- </li> -->
          <li class="header__nav-li">
            <!-- <a class="header__nav-link" href="#promo">Акции</a> -->
            <NuxtLink class="header__nav-link" to="/#promo">Акции</NuxtLink>
            <!-- <NuxtLink class="header__nav-link" :to="{ path: '/', query: {scrollTo: 'promo'} }">Акции</NuxtLink> -->
          </li>
          <!-- <li class="header__nav-li"> -->
            <!-- <a class="header__nav-link" href="#reviews">Ваши вопросы</a> -->
            <!-- <NuxtLink class="header__nav-link" @click="handleClick">Ваши вопросы</NuxtLink> -->
          <!-- </li> -->
          <li class="header__nav-li">
            <!-- <a class="header__nav-link" href="#reviews">Отзывы</a> -->
            <NuxtLink class="header__nav-link" @click="handleClick">Отзывы</NuxtLink>
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>

<style scoped lang="scss">
@use "./assets/css/header.scss" as *;
</style>
