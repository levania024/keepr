<script setup>
import CreateKeep from './components/CreateKeep.vue';
import CreateVault from './components/globals/CreateVault.vue';
import ModalWrapper from './components/ModalWrapper.vue';
import Navbar from './components/Navbar.vue';
</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>

  <ModalWrapper modalId="keep" header="Add your keep">
    <CreateKeep/>
  </ModalWrapper>

  <ModalWrapper modalId="vault" header="Add your Vault">
    <CreateVault/>
  </ModalWrapper>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';
:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
