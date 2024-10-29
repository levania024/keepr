<script setup>
import { Keep } from '@/models/Keep.js';
import ProfileCard from './ProfileCard.vue';
import { keepsService } from '@/services/KeepsService.js';

const keepProps = defineProps({ keepProp: { type: Keep, required: true } })

function setKeep(){
    keepsService.setKeep(keepProps.keepProp)
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
                <RouterLink :to="{name:'Account'}">
                    <ProfileCard :profileProp="keepProp.creator" />
                </RouterLink>
            </span>
        </div>
    </div>
</template>

<style lang="scss" scoped>
h5 {
    position: absolute;
    bottom: 0;
    text-shadow: 0px 0px var(--bs-light);
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