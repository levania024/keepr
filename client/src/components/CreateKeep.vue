<script setup>
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { ref } from 'vue';

const editableData = ref({
    name: '',
    img: '',
    description: ''
})

async function createKeep() {
    try {
        await keepsService.createKeep(editableData.value)
        editableData.value = {
            name: '',
            img: '',
            description: ''
        }
    }
    catch (error) {
        Pop.error(error);
    }
}
</script>

<template>
    <form @submit.prevent="createKeep()">
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
            <textarea v-model="editableData.description" type="Description" class="form-control-plaintext"
                id="Description" required maxlength="1000"></textarea>
            <label for="floatingPlaintextInput">Description...</label>
            <hr>
        </div>
        <div class="text-end">
            <button class="btn btn-dark" type="submit">Create</button>
        </div>
    </form>
</template>

<style lang="scss" scoped></style>