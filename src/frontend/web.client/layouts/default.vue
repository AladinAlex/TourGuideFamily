
<script setup lang="ts">
  import Header from '~/components/Header.vue'
  import Footer from '~/components/Footer.vue'

</script>

<template>
  <div class="container">
    <Header />
    <main class="content">
      <slot />
    </main>
    <Footer />
  </div>
</template>

<style scoped lang="scss">
</style>