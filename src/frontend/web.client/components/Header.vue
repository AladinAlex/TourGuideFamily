<script setup lang="ts">
const isMenuOpen = ref(false);

const toggleMenu = () => {
  isMenuOpen.value = !isMenuOpen.value;
};
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
        <span class="logo-text">BRUSNIKA</span>
        <span class="logo-text2">By Aladinskiy Family</span>
      </div>
    </div>
    <div class="header__menu">
      <button class="header__mobile-menu" @click="toggleMenu">☰</button>
      <nav class="header__nav" :class="{ 'header__nav--active': isMenuOpen }">
        <ul class="header__nav-ul list-reset">
          <li class="header__nav-li">
            <a class="header__nav-link" href="#tours">Туры</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" href="#about">Наша команда</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" href="#reviews">Контакты</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" href="#reviews">Ваши вопросы</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" href="#reviews">Отзывы</a>
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>

<style scoped lang="scss">
@use "./assets/css/header.scss" as *;
</style>
