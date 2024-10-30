<script setup>
import { AppState } from '@/AppState.js';
import { computed, ref } from 'vue';
import ProfileCard from './ProfileCard.vue';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';

const keep = computed(() => AppState.activeKeep)
const account = computed(() => AppState.account)
// const route = useRoute()
const vaults = computed(() => AppState.vaults)

const vaultKeepData = ref({
    vaultId: 0,
    keepId: 0
})

async function createVaultKeep() {
    try {
        vaultKeepData.value.keepId = AppState.activeKeep.id
        await vaultKeepsService.createVaultKeep(vaultKeepData.value)
        vaultKeepData.value = {
            vaultId: 0,
            keepId: 0
        }

        Modal.getOrCreateInstance('#keepModal').hide()
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>

<template>
    <div class="modal fade" id="keepModal" aria-hidden="true" aria-labelledby="keepModalLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div v-if="keep" class="modal-content d-flex flex-row">
                <section class="row">
                    <div class="col-lg-6 order-1 order-0">
                        <img :src="keep.img" class="img-fluid rounded-start" :alt="keep.creator.name">
                    </div>
                    <div class="col-lg-6 order-0 order-1">
                        <div class="d-flex flex-column justify-content-center">
                            <div class="text-center my-3">
                                <i class="mdi mdi-eye-outline fs-4 me-3">{{ keep.views }}</i>
                                <i class="mdi mdi-alpha-k-box-outline fs-4 me-2">{{ keep.kept }}</i>
                            </div>
                            <div class="my-5">
                                <h5 class="marko-one text-center">{{ keep.name }}</h5>
                                <p class="inter">{{ keep.description }}</p>
                            </div>
                        </div>

                        <div class="d-flex align-items-end justify-content-center">
                            <div class="col-md-6 mb-md-0">
                                <select v-model="vaultKeepData.vaultId" class="form-select form-select-lg"
                                    aria-label="select a keep" required>
                                    <option selected disabled>Select a Vault</option>
                                    <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{ vault.name }}
                                    </option>
                                </select>
                            </div>
                            <button class="btn btn-secondary shadow mx-2" @click="createVaultKeep()">Save</button>
                            <RouterLink :to="{ name: 'Profile', params: { profileId: account?.id } }"
                                :title="'Go to the profile page'">
                                <div class="d-flex ms-3">
                                    <ProfileCard :profileProp="account" />
                                    <h5 class="marko-one mx-2 text-dark align-self-center">{{ account.name }}</h5>
                                </div>
                            </RouterLink>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>

</style>