<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import KeepModal from '@/components/globals/keepModal.vue';
import { keepsService } from '@/services/KeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const keeps = computed(() => AppState.keeps)

onMounted(() => {
  getAllKeep()
})

async function getAllKeep() {
  try {
    await keepsService.getAllKeep()
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}
</script>

<template>
  <div class="container">
    <section class="grid-container mt-3">
      <div v-for="keep in keeps" :key="keep.id">
        <KeepCard :keepProp="keep" buttonType="save" />
      </div>
    </section>
    <KeepModal />
  </div>
</template>

<style scoped lang="scss">
.grid-container {
  columns: 300px;
  column-gap: 1rem;
}
</style>
