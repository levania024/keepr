<script setup>
import { AppState } from '@/AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { computed, ref } from 'vue';

const vault = computed(()=> AppState.vault)


const editableData = ref({
    name: '',
    isPrivate: '',
})

async function updateVault(vaultId) {
    try {
        await vaultsService.updateVault(vaultId,editableData.value)
        editableData.value = {
            name: '',
            isPrivate: '',
        }
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>


<template>
    <form @submit.prevent="updateVault(vault.id)">
        <div class="form-floating mb-3">
            <input v-model="editableData.name" type="text" class="form-control-plaintext" id="Name" required
                maxlength="255">
            <label for="floatingEmptyPlaintextInput">Name</label>
            <hr>
        </div>
        <div class="mb-3 text-end">
            <label for="floatingPlaintextInput" class="d-block">Private Vaults can only be seen by you</label>
            <input v-model="editableData.isPrivate" type="checkbox" id="isPrivate"> <label for=""><b>Make Vault
                    Private?</b></label>
        </div>
        <div class="text-end">
            <button class="btn btn-dark" type="submit">Update Vault</button>
        </div>
    </form>
</template>


<style lang="scss" scoped></style>