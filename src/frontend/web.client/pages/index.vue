<script setup lang="ts">
  import Presentation from '~/components/Presentation.vue'
  import AboutUs from '~/components/AboutUs.vue'
  import Tours from '~/components/Tours.vue'
  import Promo from '~/components/Promo.vue'
  import FeedbackForm from '~/components/FeedbackForm.vue'
</script>

<template>
  <main class="page">
    <div class="main-page">
      <Presentation />
      <AboutUs />
      <Tours />
      <Promo />
      <FeedbackForm />
    </div>
  </main>
</template>
