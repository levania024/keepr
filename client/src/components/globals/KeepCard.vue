<script setup>
import { Keep } from '@/models/Keep.js';
import ProfileCard from './ProfileCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { computed } from 'vue';
import { AppState } from '@/AppState.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import KeepModal from './keepModal.vue';

const props = defineProps({
    keepProp: { type: Keep, required: true },
    buttonType: { type: String, default: 'save' }
});
const account = computed(() => AppState.account)

function setKeep() {
    keepsService.setKeep(props.keepProp)
    getKeepById()
}

async function getKeepById() {
    try {
        await keepsService.getKeepById(props.keepProp.id)
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}

async function deleteKeep() {
    try {
        const deleteKeep = await Pop.confirm(`Are you sure you want to delete ${props.keepProp.name}`)
        if (!deleteKeep) return
        await keepsService.deleteKeep(props.keepProp.id)
        Pop.success(`${props.keepProp.name} is deleted`)
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}
</script>

<template>
    <div class="grid-item">
        <div class="position-relative">
            <a href="#" data-bs-toggle="modal" data-bs-target="#keepModal" @click="setKeep()">
                <img :src="keepProp.img" class="card-img-top rounded shadow" :alt="keepProp.creator.name">
                <h5 class="m-2 text-light fs-4 marko-one">{{ keepProp.name }}</h5>
            </a>
            <span class="m-2">
                <ProfileCard :profileProp="keepProp.creator" />
            </span>
            <div v-if="account?.id == keepProp.creatorId">
                <i @click="deleteKeep()" class="mdi mdi-alpha-x-circle-outline text-danger fs-4"
                    title="Manage keep"></i>
            </div>
            <KeepModal :buttonType="buttonType" />
        </div>
    </div>
</template>

<style lang="scss" scoped>
h5 {
    position: absolute;
    bottom: 0;
    text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.705);
}

i {
    position: absolute;
    top: 0;
    right: 0;
    cursor: pointer;
}

span {
    position: absolute;
    bottom: 0;
    right: 0;
}

.grid-item {
    display: inline-block;
    width: 100%;
    padding: 10px;
}
</style>