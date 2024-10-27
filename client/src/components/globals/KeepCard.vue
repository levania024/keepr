<script setup>
import { Keep } from '@/models/Keep.js';
import ProfileCard from './ProfileCard.vue';

defineProps({ keepProp: { type: Keep, required: true } })
</script>

<template>
    <RouterLink :to="{name: 'Modal', params:{keepId: keepProp.id}}" data-bs-toggle="modal" data-bs-target="#cardDetail">
        <div class="position-relative">
            <img :src="keepProp.img" class="card-img-top rounded shadow" :alt="keepProp.creator.name">
            <h5 class="m-2 text-light">{{ keepProp.name }}</h5>
            <span class="m-2">
                <ProfileCard :profileProp="keepProp.creator" />
            </span>
        </div>
    </RouterLink>
</template>

<style lang="scss" scoped>
h5 {
    position: absolute;
    bottom: 0;
}

span {
    position: absolute;
    bottom: 0;
    right: 0;
}
</style>