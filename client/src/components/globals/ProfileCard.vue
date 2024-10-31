<script setup>
import { Profile } from '@/models/Profile.js';
defineProps({ profileProp: { type: Profile, required: true } })
</script>

<template>
    <img :src="profileProp.picture" :alt="profileProp.name" :title="profileProp.name">
</template>

<style lang="scss" scoped>
img {
    width: 50px;
    border-radius: 50%;
    aspect-ratio: 1/1;
    object-fit: cover;
    object-position: center
}
</style>