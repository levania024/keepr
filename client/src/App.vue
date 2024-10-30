<script setup>
import AccountForm from './components/accountForm.vue';
import CreateKeep from './components/CreateKeep.vue';
import CreateVault from './components/globals/CreateVault.vue';
import EditVault from './components/globals/EditVault.vue';
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
    <CreateKeep />
  </ModalWrapper>

  <ModalWrapper modalId="vault" header="Add your Vault">
    <CreateVault />
  </ModalWrapper>

  <ModalWrapper modalId="account" header="Edit Account Page">
    <AccountForm />
  </ModalWrapper>

  <ModalWrapper modalId="editVault" header="Edit Vault">
    <EditVault />
  </ModalWrapper>

</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
