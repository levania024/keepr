<script setup>
import { accountService } from '@/services/AccountService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { ref } from 'vue';

const editableData = ref({
    name: '',
    picture: '',
    coverImg: ''
})

async function updateAccount() {
    try {
        await accountService.updateAccount(editableData.value)
        editableData.value = {
            name: '',
            picture: '',
            coverImg: ''
        }
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}

</script>


<template>
    <form @submit.prevent="updateAccount()">
        <div class="mb-3">
            <input v-model="editableData.name" type="text" class="form-control" id="name" placeholder="Name" required
                maxlength="255">
        </div>
        <div class="mb-3">
            <input v-model="editableData.picture" class="form-control" id="picture" rows="3" type="url" required
                placeholder="Picture" maxlength="1000">
        </div>
        <div class="mb-3">
            <input v-model="editableData.coverImg" class="form-control" id="coverImg" rows="3" type="url" required
                placeholder="CoverImg" maxlength="1000">
        </div>
        <div>
            <button type="submit" class="btn btn-info">Submit</button>
        </div>
    </form>
</template>


<style lang="scss" scoped></style>