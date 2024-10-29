<script setup>
import CardDetail from '@/components/globals/keepModal.vue';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

onMounted(()=>{
    getVaultById()
})

async function getVaultById() {
    try 
    {
        await vaultsService.getVaultById(route.params.vaultId)
    }
    catch (error) {
        Pop.error(error);
        logger.log(error)
    }
}

</script>


<template>
    <CardDetail />
</template>


<style lang="scss" scoped></style>