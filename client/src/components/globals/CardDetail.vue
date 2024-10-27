<script setup>
import { AppState } from '@/AppState.js';
import { computed, ref } from 'vue';
import ProfileCard from './ProfileCard.vue';

const keeps = computed(() => AppState.keeps)
const selectKeep = computed(() => AppState.keeps.find(keep => keep.id == editableData.value.keepId))

const editableData = ref({
    isPrivate: '',
    keepId: 0
})

</script>

<template>
    <div class="container ">
        <div v-if="selectKeep" class="card mb-3">
            <section class="row g-0">
                <div class="col-lg-12 col-md-6">
                    <img :src="selectKeep.img" class="img-fluid rounded-start" :alt="selectKeep.creator.name">
                </div>
                <div class="col-lg-12 col-md-6">
                    <div class="card-body">
                        <div>
                            <i class="mdi mdi-eye">{{ selectKeep.views }}</i>
                            <i class="mdi mdi-alpha-k-box-outline">{{ selectKeep.kept }}</i>
                        </div>
                        <h5 class="card-title">{{ selectKeep.name }}</h5>
                        <p class="card-text">{{ selectKeep.description }}</p>
                    </div>
                </div>
                <div class="d-flex">
                    <select name="form-select" v-model="editableData.keepId" required aria-label="select a keep">
                        <option selected :value="keep.id" disabled v-for="keep in keeps" :key="keep.id">{{ keep.name }}
                        </option>
                    </select>
                    <button class="btn btn-secondary" type="submit">Save</button>
                    <ProfileCard :profileProp="selectKeep.creator" />
                </div>
            </section>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>