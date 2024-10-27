<script setup>
import { AppState } from '@/AppState.js';
import CardDetail from '@/components/globals/CardDetail.vue';
import KeepCard from '@/components/globals/KeepCard.vue';
import ModalWrapper from '@/components/ModalWrapper.vue';
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
    Pop.error(error);
    logger.log(error)
  }
}
</script>

<template>
  <div class="container">
    <ModalWrapper modalId="cardDetail">
      <CardDetail />
    </ModalWrapper>
    <section class="row gap-3 mt-3">
      <div v-for="keep in keeps" :key="keep.id" class="col-lg-3 col-md-6 mb-3">
        <KeepCard :keepProp="keep" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss"></style>
