<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import ProfileCard from '@/components/globals/ProfileCard.vue';
import KeepCard from '@/components/globals/KeepCard.vue';

const account = computed(() => AppState.account)
const keeps = computed(() => AppState.keeps)

// async function getMyVault(params) {
  
// }

</script>

<template>
  <div class="about">
    <div v-if="account">
      <div class="text-center">
        <ProfileCard :profileProp="account" />
        <p>{{ account.name }}</p>
      </div>
      <div class="container d-flex justify-content-center">
        <p>vault</p> 
        |
        <p>keeps</p>
      </div>
      <div class="container">
        <div>
          <h3>Vaults</h3>
        </div>
        <div>
          <h3>Keeps</h3>
          <div class="container">
            <div v-for="keep in keeps" :key="keep.id">
            <KeepCard :keepProp="keep" />
          </div>
      </div>
        </div>
      </div>
    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
</template>

<style scoped lang="scss">
.grid-container {
  columns: 300px;
  column-gap: 1rem;
}
</style>
