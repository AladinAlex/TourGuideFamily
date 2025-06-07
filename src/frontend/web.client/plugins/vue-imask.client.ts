import { defineNuxtPlugin } from '#app';
import { IMaskComponent, IMaskDirective } from 'vue-imask';

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component('IMaskInput', IMaskComponent);
  nuxtApp.vueApp.directive('imask', IMaskDirective);
});
