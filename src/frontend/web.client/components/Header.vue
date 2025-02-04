<script setup lang="ts"></script>

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
          <span class="logo-text">BRUSNIKA</span>
        </div>
        <div>
          <span class="logo-text2">By Aladinskiy Family</span>
        </div>
      </div>
    </div>
    <div class="header__menu">
      <nav class="header__nav">
        <ul class="header__nav-ul list-reset" data-header="nav-ul">
          <li class="header__nav-li">
            <a class="header__nav-link" name="tours">Туры</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" name="about">Наша команда</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" name="reviews">Контакты</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" name="reviews">Ваши вопросы</a>
          </li>
          <li class="header__nav-li">
            <a class="header__nav-link" name="reviews">Отзывы</a>
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>

<style scoped lang="scss">
@use "./assets/css/header.scss" as *;
</style>
