<script setup>
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { ref } from 'vue';

const editableData = ref({
    name: '',
    img: '',
    description: '',
    isPrivate: ''
})


async function createVault() {
    try {
        await vaultsService.createVault(editableData.value)
        editableData.value = {
            name: '',
            img: '',
            description: '',
            isPrivate: ''
        }
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>


<template>
    <form @submit.prevent="createVault()">
        <div class="form-floating mb-3">
            <input v-model="editableData.name" type="text" class="form-control-plaintext" id="Name" required
                maxlength="255">
            <label for="floatingEmptyPlaintextInput">Name...</label>
            <hr>
        </div>
        <div class="form-floating mb-3">
            <input v-model="editableData.img" type="url" class="form-control-plaintext" id="image" required
                maxlength="1000">
            <label for="floatingPlaintextInput">Image Url...</label>
            <hr>
        </div>
        <div class="form-floating mb-3">
            <textarea v-model="editableData.description" type="text" class="form-control-plaintext"
                id="Description" required maxlength="1000"></textarea>
            <label for="floatingPlaintextInput">Description...</label>
            <hr>
        </div>
        <div class="mb-3 text-end">
            <label for="floatingPlaintextInput" class="d-block">Private Vaults can only be seen by you</label>
            <input v-model="editableData.isPrivate" type="checkbox"
                id="isPrivate"> <label for=""><b>Make Vault Private?</b></label>
        </div>
        <div class="text-end">
            <button class="btn btn-dark" type="submit">Create Vault</button>
        </div>
    </form>
</template>


<style lang="scss" scoped>

</style>