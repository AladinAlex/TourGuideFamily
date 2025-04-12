<script setup lang="ts">

defineEmits(["close"]);
</script>

<template>
  <div class="modal-content">
    <button @click="$emit('close')" class="close-button">&times;</button>
    <div class="section">
    <div class="main-container max-width">
      <h1 class="title">
        В процессе разработки...
      </h1>
    </div>
  </div>

  </div>
</template>

<style lang="scss">
.modal-content {
  position: relative;
  margin: auto;
  padding: 20px;
  border-radius: 15px;

  .close-button {
    position: absolute;
    top: 26px;
    right: 26px;
    font-size: 36px;
    background: none;
    border: none;
    cursor: pointer;
  }

  .section {
    padding: 50px !important;
    border-radius: 15px;

    @media (width <= 768px) {
      padding: 25px !important;
    }
  }
}
</style>
