<script setup lang="ts">
import type { PropType } from "vue";
import SeparateLine from "~/components/SeparateLine.vue";

const props = defineProps({
  price: {
    type: Number,
    required: true,
  },
  included: {
    type: Array as PropType<String[]>,
    required: true,
  },
  excluded: {
    type: Array as PropType<String[]>,
    required: true,
  },
});
</script>

<template>
  <section class="price-info section">
    <div class="main-container max-width">
      <SeparateLine />
      <h3 class="price-info__header">
        Покупая тур у нас, вы получаете больше, чем просто отдых. Вы становитесь
        частью нашей семьи, где каждому гостю уделяют внимание и заботу.
      </h3>
      <!-- <h1 class="price-info__title title">
        Стоимость тура {{ formatPrice(props.price) }}
      </h1> -->
    </div>

    <div class="main-container max-width">
      <div class="tour-inclusions">
        <div class="columns">
          <div class="column included">
            <h3 class="column__title">Включено в стоимость:</h3>
            <ul>
              <li v-for="(item, index) in included" :key="index">
                <span class="check-icon">&#10004;</span> {{ item }}
              </li>
            </ul>
          </div>

          <div class="column excluded">
            <h3 class="column__title">Не включено:</h3>
            <ul>
              <li v-for="(item, index) in excluded" :key="index">
                <span class="cross-icon">&#10006;</span> {{ item }}
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/presentationTour.scss" as *;
</style>
