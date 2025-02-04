<script setup lang="ts"> 
import { useRoute } from 'vue-router' 
 
const route = useRoute() 
const layout = ref() 
 
watch( 
  () => route.meta, 
  async (newMeta, oldMeta) => { 
    if ( 
      newMeta?.layout === undefined || 
      (newMeta?.layout || 'default') !== (oldMeta?.layout || 'default') 
    ) { 
      // document.title = (newMeta.title as string) || 'Камчатка' 
      layout.value = markRaw( 
        defineAsyncComponent(() => import(`@/layout/${newMeta?.layout || 'default'}.vue`)), 
      ) 
    } 
  }, 
  { immediate: true }, 
) 
</script>

<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<style lang="scss">
@use '@/assets/css/main.scss';
</style>