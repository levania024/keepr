<script setup>
import { AppState } from '@/AppState.js';
import { computed, onMounted, ref } from 'vue';
import ProfileCard from './ProfileCard.vue';
import { useRoute, useRouter } from 'vue-router';
import Pop from '@/utils/Pop.js';
import { keepsService } from '@/services/KeepsService.js';
import { logger } from '@/utils/Logger.js';
import { Vault } from '@/models/Vault.js';
import { Modal } from 'bootstrap';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';

const keep = computed(() => AppState.activeKeep)
// const vaultKeeps = computed(()=> AppState.vaulKeeps)
// const profile = computed(() => AppState.profile)
const account = computed(()=> AppState.account)
// const route = useRoute()
// const router = useRouter()

// defineProps({ vaults: { type: Vault, required: true } })

// onMounted(() => {
//     getKeepById()
// })

// async function getKeepById() {
//     try {
//         await keepsService.getKeepById(route.params.keepId)
//     }
//     catch (error) {
//         Pop.error(error);
//         logger.log(error)
//     }
// }

const vaultKeepData = ref({
    vaultId: null,
    keepId: null
})

async function createVaultKeep() {
    try {
        vaultKeepData.value.keepId = AppState.activeKeep
        vaultKeepData.value.vaultId = AppState.vault
        await vaultKeepsService.createVaultKeep(vaultKeepData.value)

        //   Modal.getOrCreateInstance('#keepModal')
    }
    catch (error) {
        Pop.error(error);
    }
}

</script>

<template>
    <div class="modal fade" id="keepModal" aria-hidden="true" aria-labelledby="keepModalLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div v-if="keep" class="modal-content">
                <div class="modal-body">
                    <div class="container">
                        <div class="d-flex">
                            <section class="row order-1 order-0">
                                <div class="col-lg-12 col-md-6">
                                    <div>
                                        <img :src="keep.img" class="img-fluid rounded-start" :alt="keep.creator.name">
                                    </div>
                                </div>
                            </section>
                            <section class="row order-0 order-1">
                                <div class="col-lg-12 col-md-6">
                                    <div class="mx-2">
                                        <div class="text-center">
                                            <i class="mdi mdi-eye-outline fs-4 me-3">{{ keep.views }}</i>
                                            <i class="mdi mdi-alpha-k-box-outline fs-4 me-2">{{ keep.kept }}</i>
                                        </div>
                                        <div class="d-flex flex-column justify-content-center align-items-center">
                                            <h5 class="marko-one">{{ keep.name }}</h5>
                                            <p class="inter ms-5">{{ keep.description }}</p>
                                        </div>
                                    </div>
                                    <div class="d-flex ms-5 ">
                                        <!-- <select name="name" required aria-label="select a keep"
                                            class="form-select-plaintext">
                                            <option selected :value="vault.id" disabled :key="vault.id"
                                                v-for="vault in vaults"> {{ vault.name }}
                                            </option>
                                        </select> -->

                                        <a href="#" class="btn btn-secondary shadow mx-auto" role="button"
                                            @click="createVaultKeep()">Save</a>

                                        <RouterLink :to="{ name: 'Profile', params: { profileId: account.id } }"
                                            :title="'Go to the profile page'">
                                            <div class="d-flex align-items-center ms-auto p-2">
                                                <ProfileCard :profileProp="account" />
                                                <h5 class="marko-one mx-2 text-dark">{{ account.name }}</h5>
                                            </div>
                                        </RouterLink>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped></style>