<script setup>
import { Vault } from '@/models/Vault.js';

const vaultProps = defineProps({ vaultProp: { type: Vault, required: true } })

</script>


<template>
    <div class="position-relative">
        <img :src="vaultProp.img" class="card-img-top rounded shadow" :alt="vaultProp.creator.name">
        <h5 class="m-2 text-light fs-4 marko-one">{{ vaultProp.name }}</h5>
        <span class="m-2">
            <ProfileCard :profileProp="vaultProp.creator" />
        </span>
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
</style>