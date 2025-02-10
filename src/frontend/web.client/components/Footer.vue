<script setup lang="ts">
var year = new Date().getFullYear();
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
            <li class="footer__nav-li">
              <NuxtLink to="/" class="footer__link">Все туры</NuxtLink>
            </li>
            <li class="footer__nav-li">
              <NuxtLink to="/" class="footer__link"
                >Ниже будет список топ 5 туров</NuxtLink
              >
            </li>
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
              <NuxtLink to="/" class="footer__link"
                >Политика конфиденциальности</NuxtLink
              >
            </li>
          </ul>
        </div>
        <div class="footer__nav">
          <span class="footer__title">Связаться</span>
          <ul class="footer__nav-list list-reset">
            <li class="footer__nav-li">
              <span class="footer__text">+7 (905) 494-83-77</span>
            </li>
            <li class="footer__nav-li">
              <div class="footer__social-link">
                <NuxtLink to="/">
                  <img
                    src="@/assets/images/telegram.png"
                    class="footer__social-link__image"
                  />
                </NuxtLink>
                <NuxtLink to="/">
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
