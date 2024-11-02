<script setup>
import { AppState } from '@/AppState.js';
import { computed, ref } from 'vue';
import ProfileCard from './ProfileCard.vue';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { logger } from '@/utils/Logger.js';

const keep = computed(() => AppState.activeKeep)
const vaults = computed(() => AppState.myVaults)


const vaultKeepData = ref({
    vaultId: 0,
    keepId: 0
})

const props = defineProps({
    buttonType: { type: String, default: 'save' }
});

async function handleButtonAction() {
    try {
        if (props.buttonType == 'save') {
            vaultKeepData.value.keepId = AppState.activeKeep.id;
            await vaultKeepsService.createVaultKeep(vaultKeepData.value);
            Pop.success(`Keep saved successfully ${keep.value.name}!`);
        } 
        else if (props.buttonType == 'remove') {
             Pop.confirm(`Are you sure you want to remove this keep ${keep.value.name}?, Use delete button on the keep image to remove ${keep.value.name}` );
        }
        closeModal();
    } catch (error) {
        Pop.error(error);
        logger.log(error);
    }
}

function closeModal() {
    Modal.getOrCreateInstance('#keepModal').hide()
}
</script>

<template>
    <div class="modal fade" id="keepModal" aria-hidden="true" aria-labelledby="keepModalLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div v-if="keep" class="modal-content">
                <section class="row">
                    <div class="col-lg-6 col-md-12 order-0 order-md-1 d-flex flex-column justify-content-between d-md-flex">
                        <img :src="keep.img" class="keepImg rounded-start" :alt="keep.creator.name">
                    </div>
                    <div class="col-lg-6 col-md-12 order-0 order-md-1 d-flex flex-column justify-content-between d-md-flex">
                        <div class="d-flex flex-column justify-content-center align-items-center">
                            <div class="text-center p-3 my-3">
                                <i class="mdi mdi-eye-outline fs-4 me-3">{{ keep.views }}</i>
                                <i class="mdi mdi-alpha-k-box-outline fs-4 me-2">{{ keep.kept }}</i>
                            </div>
                            <div class="p-3 text-center">
                                <h5 class="marko-one">{{ keep.name }}</h5>
                                <p class="inter">{{ keep.description }}</p>
                            </div>
                        </div>

                        <div class="d-flex align-items-end mb-3">
                            <div v-if="props.buttonType == 'save'" class="col-md-6 mb-md-0">
                                <select v-model="vaultKeepData.vaultId" class="form-select" aria-label="select a keep"
                                    required>
                                    <option selected disabled :value="0">Select a Vault</option>
                                    <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{ vault.name }}
                                    </option>
                                </select>
                            </div>
                            <div>
                                <button class="btn btn-secondary shadow mx-2" @click="handleButtonAction()">
                                    {{ props.buttonType == 'save' ? 'Save' : 'Remove' }}
                                </button>
                            </div>

                            <RouterLink :to="{ name: 'Profile', params: { profileId: keep.creator.id } }"
                                :title="'Go to the profile page'" @click="closeModal()">
                                <div class="d-flex ms-5">
                                    <ProfileCard :profileProp="keep.creator" />
                                    <h5 class="marko-one mx-2 text-dark align-self-center">{{ keep.creator.name }}</h5>
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
.modal-content {
    display: flex;
    flex-direction: row;
    overflow: hidden;
}

.section {
    flex: 1;
}

.keepImg {
    height: 100%;
    width: 100%;
    object-fit: cover;
    object-position: center;
}
</style>