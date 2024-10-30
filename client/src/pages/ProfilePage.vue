<script setup>
import { AppState } from '@/AppState.js';
import VaultCard from '@/components/globals/VaultCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { profilesService } from '@/services/ProfilesService.js';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const account = computed(() => AppState.account)
const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

onMounted(() => {
  getUserProfile()
  getUserKeep()
  getUserVault()
})

async function getUserProfile() {
  try {
    await profilesService.getUserProfile(route.params.profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getUserKeep() {
  try {
    await keepsService.getUserKeep(route.params.profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getUserVault() {
  try {
    await vaultsService.getUserVault(route.params.profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>


<template>
  <h1 class="text-center">Profile page</h1>
  <div v-if="account">
    <div class="container">
      <section class="row position-relative">
        <img class="creatorImg rounded-4" :src="account.coverImg" :alt="account.name">
        <div class="d-flex justify-content-center">
          <div class="my-4">
            <img :src="account.picture" alt="" class="profileImg">
          </div>
        </div>
      </section>

      <div class="text-center">
        <h3>{{ account.name }}</h3>
        <p>{{ vaults?.length }} vault |
          {{ keeps?.length }} keeps
        </p>
      </div>
    </div>

    <div class="container">
      <section class="row g-4">
        <h4>Vault</h4>
        <div v-for="vault in vaults" :key="vault.id" class="col-lg-3 mb-3">
          <VaultCard :vaultProp="vault" />
        </div>
        
        <div class="col-lg-12">
          <h4>Keep</h4>
          <section class="grid-container mt-3">
            <div v-for="keep in keeps" :key="keep.id">
              <KeepCard :keepProp="keep" />
            </div>
          </section>
        </div>
      </section>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.creatorImg {
  height: 40dvh;
  object-fit: cover;
  object-position: center;
}

.grid-container {
  columns: 300px;
  column-gap: 1rem;
}

.profileImg {
  position: absolute;
  bottom: 0;
  height: 15dvh;
  border-radius: 50%;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center
}
</style>