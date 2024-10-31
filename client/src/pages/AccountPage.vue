<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '@/components/globals/KeepCard.vue';
import Pop from '@/utils/Pop.js';
import { vaultsService } from '@/services/VaultsService.js';

const account = computed(() => AppState.account)
const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

onMounted(() => {
  getMyVault()

})

async function getMyVault() {
  try {
    await vaultsService.getMyVault()
  }
  catch (error) {
    Pop.error(error);
  }
}


</script>

<template>
  <div class="about">
    <div v-if="account">
      <div class="container">
        <section class="row position-relative">
          <img class="creatorImg rounded-4 mt-3" :src="account.coverImg" :alt="account.name">
          <div class="">
            <div class="text-end">
              <div class="dropdown">
                <i class="mdi mdi-dots-horizontal fs-3" type="button" data-bs-toggle="dropdown"
                  aria-expanded="false"></i>
                <ul class="dropdown-menu">
                  <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#account">Edit
                      Account</a></li>
                </ul>
              </div>
            </div>
            <div class="my-4 text-center">
              <img :src="account.picture" alt="" class="profileImg">
            </div>
          </div>
        </section>
        <div class="text-center">
          <h2>{{ account.name }}</h2>
          <p>{{ vaults.length }} vault |
            {{ keeps?.length }} keeps
          </p>
        </div>
      </div>
      <div class="container">
        <section class="row g-4">
          <h3>Vault</h3>
          <div v-for="vault in vaults" :key="vault.id" class="col-lg-3">
            <VaultCard :vaultProp="vault" />
          </div>
          <div class="col-lg-12">
            <h3>Keep</h3>
            <section class="grid-container mt-3">
              <div v-for="keep in keeps" :key="keep.id">
                <KeepCard :keepProp="keep" />
              </div>
            </section>
          </div>
        </section>
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

.creatorImg {
  height: 40dvh;
  object-fit: cover;
  object-position: center;
}

.profileImg {
  position: absolute;
  bottom: 0;
  height: 10dvh;
  border-radius: 50%;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center
}
</style>
