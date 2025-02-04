<script setup lang="ts">

  var title = 'Полуостров Камчатка'
  var description = 'Камчатка, нетронутая дикая природа российского Дальнего Востока - место, не похожее ни на одно другое. Высокие вулканы, чистейшие озера'
  var buttonText = 'Оставить заявку'

  const handleClick = () => { }
</script>

<template>
  <div class="presentation">
    <div class="presentation__left">
      <img src='@/assets/images/presentation.jpg' alt="Изображение" class="presentation__left-image" />
    </div>
    <div class="presentation__right">
      <div class="presentation__right-content">
        <h1 class="title">{{ title }}</h1>
        <p class="description">{{ description }}</p>
        <button class="button" @click="handleClick">{{ buttonText }}</button>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
    @use './assets/css/presentation.scss' as *;
</style>