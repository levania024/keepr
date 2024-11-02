<script setup>
import { AppState } from '@/AppState.js';
import { accountService } from '@/services/AccountService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, ref, watch } from 'vue';
const account = computed(() => AppState.account)

const editableData = ref({
    name: '',
    picture: '',
    coverImg: ''
})

watch(account, (newAccount) => {
    editableData.value.name = newAccount?.name
    editableData.value.picture = newAccount?.picture
    editableData.value.coverImg = newAccount?.coverImg
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
        <section class="row d-flex">
            <div class="col-lg-4">
                <img v-if="editableData.picture" :src="editableData.picture" alt="" class="img-fluid">
                <img v-else src="https://placehold.co/400" class="img-thumbnail" alt="...">
            </div>

            <div class="col-lg-8">
                <div class="mb-3">
                    <label for="name" class="d-block">Account Name</label>
                    <input v-model="editableData.name" type="text" class="form-control" id="name" placeholder="Name"
                        required maxlength="255">
                </div>
                <div class="mb-3">
                    <label for="picture" class="d-block">Account Picture</label>
                    <input v-model="editableData.picture" class="form-control" id="picture" rows="3" type="url" required
                        placeholder="Picture" maxlength="1000">
                </div>
                <div class="mb-3">
                    <label for="coverImg" class="d-block">Account CoverImg</label>
                    <input v-model="editableData.coverImg" class="form-control" id="coverImg" rows="3" type="url"
                        required placeholder="CoverImg" maxlength="1000">
                </div>
                <div>
                    <button type="submit" class="btn btn-info">Submit</button>
                </div>
            </div>

        </section>

    </form>
</template>


<style lang="scss" scoped></style>