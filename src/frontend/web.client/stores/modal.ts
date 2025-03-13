import { defineStore } from "pinia";
import type { ModalState } from "~/types/ModalState";

export const useModalStore = defineStore('modal', () => {
    const initialState = {
      component: null,
      componentProps: {}
    }
  
    const state = ref<ModalState>({ ...initialState })
  
    function open (newState: ModalState) {
      Object.assign(state.value, newState)
    }
  
    function close () {
      Object.assign(state.value, initialState)
    }
  
    return {
      state,
      open,
      close
    }
  })