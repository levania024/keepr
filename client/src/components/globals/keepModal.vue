<script setup>
import { AppState } from '@/AppState.js';
import { computed, ref } from 'vue';
import ProfileCard from './ProfileCard.vue';
// import { Vault } from '@/models/Vault.js';

const keep = computed(() => AppState.activeKeep)
const account = computed(() => AppState.account)

// const vault = computed(() => AppState.vault)

const editableData = ref({
    keepId: 0
})
</script>

<template>
    <div class="modal fade" id="keepModal" aria-hidden="true" aria-labelledby="keepModalLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div v-if="keep" class="modal-content">
                <div class="modal-body">
                    <div class="container">
                        <div class="d-flex">
                            <section class="row order-1 order-0">
                                <div class="col-lg-12 col-md-6">
                                    <img :src="keep.img" class="img-fluid rounded-start" :alt="keep.creator.name">
                                </div>
                            </section>
                            <section class="row order-0 order-1">
                                <div class="col-lg-12 col-md-6">
                                    <div class="mx-2">
                                        <div class="text-center">
                                            <i class="mdi mdi-eye fs-4">{{ keep.views }}</i>
                                            <i class="mdi mdi-alpha-k-box-outline fs-4">{{ keep.kept }}</i>
                                        </div>
                                        <h5 class="marko-one text-center">{{ keep.name }}</h5>
                                        <p class="inter align-self-center">{{ keep.description }}</p>
                                    </div>
                                    <div class="d-flex justify-content-between mx-2">
                                        <select name="name" v-model="editableData.keepId" required
                                            aria-label="select a keep" class="form-select-plaintext">
                                            <option selected :value="keep.id" disabled v-for="keep in keep"
                                                :key="keep.id"> {{ keep.name }}
                                            </option>
                                        </select>

                                        <!-- <RouterLink :to="{ name: 'Vault', params: { vaultId: vault.id } }"> -->
                                        <button class="btn btn-secondary" type="submit">Save</button>
                                        <!-- </RouterLink> -->

                                        <RouterLink :to="{ name: 'Profile', params: { profileId: account.id } }"
                                            :title="'Go to the profile page'">
                                            <div class="d-flex align-items-center">
                                                <ProfileCard :profileProp="keep.creator" />
                                                <h5 class="marko-one mx-2">{{ keep.creator.name }}</h5>
                                            </div>
                                        </RouterLink>
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped></style>