<script setup>
import { AppState } from '@/AppState.js';
import { keepsService } from '@/services/KeepsService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const keeps = computed(() => AppState.keeps)
const vault = computed(() => AppState.vault)
const router = useRouter()


const route = useRoute()

onMounted(() => {
    getVaultById()
    getKeepById()
})

async function getVaultById() {
    try {
        await vaultsService.getVaultById(route.params.vaultId)
        if(vault.value.isPrivate){
            router.push({name: 'Home'})
        }
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}

async function getKeepById() {
    try {
        await keepsService.getKeepById(route.params.vaultId)
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}


async function deleteVault(vaultId) {
    try {
        const vaultToDelete = await Pop.confirm(`Are you sure you want to delete ${vault.value.name}`)
        if (!vaultToDelete) return

        await vaultsService.deleteVault(vaultId)

        Pop.toast(`${vault.value.name} is deleted`)
        router.push({name: 'Home'})
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}
</script>


<template>
    <h1 class="text-center">Vault</h1>
    <div class="container">
        <section v-if="vault" class="row position-relative">
            <div class="d-flex justify-content-center">
                <img :src="vault.img" :alt="vault.creator.name" class="vaultImg rounded-5">
                <div class="vaultCreator mb-3 text-center text-light">
                    <h2 class="fs-1 inter"><b>{{ vault.name }}</b></h2>
                    <h4 class="marko-one">By {{ vault.creator.name }}</h4>
                </div>
            </div>
        </section>

        <div class="text-end">
            <div  class="dropdown">
                <i class="mdi mdi-dots-horizontal fs-2" type="button" data-bs-toggle="dropdown" aria-expanded="false"></i>
                <ul class="dropdown-menu">
                    <li>
                        <a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#editVault">Edit
                            Vault</a>
                    </li>
                    <hr>
                    <li>
                        <button  @click="deleteVault(vault.id)" class="dropdown-item">
                            Delete Vault
                        </button>
                    </li>
                </ul>
            </div>
        </div>

        <div v-if="keeps" class="text-center">
            <p>{{ keeps?.length }}
                <span>Keeps</span>
            </p>
        </div>
    </div>
    <div class="container">
        <section class="grid-container mt-3">
            <div v-for="keep in keeps" :key="keep.id">
                <KeepCard :keepProp="keep" />
            </div>
        </section>
    </div>
</template>


<style lang="scss" scoped>
.grid-container {
    columns: 300px;
    column-gap: 1rem;
}

.vaultCreator {
    position: absolute;
    bottom: 0;
}

.vaultImg {
    height: 30dvh;
    width: 50dvh;
    object-fit: cover;
    object-position: center;
}
</style>