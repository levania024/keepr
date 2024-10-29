<script setup>
import { Keep } from '@/models/Keep.js';
import ProfileCard from './ProfileCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { computed } from 'vue';
import { AppState } from '@/AppState.js';
import Pop from '@/utils/Pop.js';

const keepProps = defineProps({ keepProp: { type: Keep, required: true } })
const account = computed(() => AppState.account)

function setKeep() {
    keepsService.setKeep(keepProps.keepProp)
}

async function deleteKeep() {
    try {
        const deleteKeep = await Pop.confirm(`Are you sure you want to delete ${keepProps.keepProp.name}`)
        if (!deleteKeep) return
        await keepsService.deleteKeep(keepProps.keepProp.id)
        Pop.toast(`${keepProps.keepProp.name} is deleted`)
    }
    catch (error) {
        Pop.error(error);
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
                <i @click="deleteKeep()" class="mdi mdi-alpha-x-circle-outline text-danger fs-4" title="delete keep"
                    type="button"></i>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
h5 {
    position: absolute;
    bottom: 0;
    text-shadow: 0px 0px var(--bs-light);
}

i {
    position: absolute;
    top: 0;
    right: 0;
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