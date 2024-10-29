<script setup>
import { AppState } from '@/AppState.js';
import ProfileCard from '@/components/globals/ProfileCard.vue';
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
const vaults = computed(() => AppState.vault)

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
  <div class="container">
    <section class="row position-relative">
      <img class="creatorImg rounded-4" :src="account.coverImg" :alt="account.name">
    </section>
    <div class="d-flex justify-content-center ">
      <div class="profileImg mb-3">
        <ProfileCard :profileProp="account" />
      </div>
    </div>
    <div class="d-flex justify-content-center">
      <p><span></span>vault</p>
      |
      <p><span></span>keeps</p>
    </div>
    <section class="row">
      <div class="col-lg-12">
        <h4>Vault</h4>
        <div v-for="vault in vaults" :key="vault.id" class="col-lg-3">
          <VaultCard :vaultProp="vault" />
        </div>
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

.profileImg {}
</style>