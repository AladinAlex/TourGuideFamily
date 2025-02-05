<script setup lang="ts">
  var year = new Date().getFullYear()
</script>

<template>
  <footer class="footer">
    <p>&copy; {{year}} Мой сайт. Все права защищены.</p>
  </footer>
</template>

<style scoped lang="scss">
.footer {
  background-color: #35495e;
  color: white;
  text-align: center;
  padding: 1rem;
}
</style>