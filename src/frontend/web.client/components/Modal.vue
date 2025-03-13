<script setup lang="ts">
import { useModalStore } from "@/stores/modal";
const modal = useModalStore();
</script>

<template>
  <div
    class="modal-overlay"
    v-if="modal.state.component"
    @click.self="modal.close"
  >
    <!-- <div class="modal-content">
      <button @click="modal.close" class="close-button">&times;</button> -->
    <Component
      :is="modal.state.component"
      v-bind="modal.state.componentProps"
      @close="modal.close"
    />
    <!-- </div> -->
  </div>
</template>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.6);
  display: flex;
  justify-content: center;
  align-items: center;
}

/* .modal-content {
  background: white;
  padding: 2rem;
  border-radius: 8px;
  max-width: 600px;
  width: 90%;
  position: relative;
}

.close-button {
  position: absolute;
  top: 10px;
  right: 10px;
  font-size: 24px;
  background: none;
  border: none;
  cursor: pointer;
} */
</style>
