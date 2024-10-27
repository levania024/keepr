<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import ProfileCard from '@/components/globals/ProfileCard.vue';

const account = computed(() => AppState.account)

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
        </div>
      </div>
    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
</template>

<style scoped lang="scss">
</style>
