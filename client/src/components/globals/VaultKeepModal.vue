<script setup>
import { AppState } from '@/AppState.js';
import { computed} from 'vue';
import ProfileCard from './ProfileCard.vue';

const keep = computed(() => AppState.activeKeep)
const account = computed(() => AppState.account)
</script>

<template>
    <div class="modal fade" id="vaultKeepModal" aria-hidden="true" aria-labelledby="vaultKeepModalLabel" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div v-if="keep" class="modal-content d-flex flex-row">
                <section class="row order-1 order-0">
                    <div class="">
                        <div>
                            <img :src="keep.img" class="img-fluid rounded-start" :alt="keep.creator.name">
                        </div>
                    </div>
                </section>
                <section class="row order-0 order-1">
                    <div class="">
                        <div class="mx-2">
                            <div class="text-center">
                                <i class="mdi mdi-eye-outline fs-4 me-3">{{ keep.views }}</i>
                                <i class="mdi mdi-alpha-k-box-outline fs-4 me-2">{{ keep.kept }}</i>
                            </div>
                            <div class="d-flex flex-column justify-content-center align-items-center">
                                <h5 class="marko-one">{{ keep.name }}</h5>
                                <p class="inter ms-5">{{ keep.description }}</p>
                            </div>
                        </div>
                        <div class="d-flex align-items-center ms-5">
                            <RouterLink :to="{ name: 'Profile', params: { profileId: account.id } }"
                                :title="'Go to the profile page'">
                                <div class="d-flex align-items-center ms-auto p-2">
                                    <ProfileCard :profileProp="account" />
                                    <h5 class="marko-one mx-2 text-dark">{{ account.name }}</h5>
                                </div>
                            </RouterLink>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped></style>