<script setup>
import { Vault } from '@/models/Vault.js';

defineProps({ vaultProp: { type: Vault, required: true } })

</script>


<template>
    <RouterLink :to="{ name: 'Vault', params: { vaultId: vaultProp.id } }">
        <div class="position-relative">
            <img :src="vaultProp.img" class="rounded shadow img-fluid" :alt="vaultProp.creator.name">
            <h5 class="m-2 text-light fs-4 marko-one">{{ vaultProp.name }}</h5>
            <span v-if="vaultProp.isPrivate">
                <i class="mdi mdi-lock-outline fs-4"></i>
            </span>
        </div>
    </RouterLink>
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
    text-shadow: 1px 1px lightblue;
}
</style>