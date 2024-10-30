<script setup>

</script>


<template>
    <form action="">
        <div class="form-floating mb-3">
            <input type="text" class="form-control-plaintext" id="Name" required maxlength="255">
            <label for="floatingEmptyPlaintextInput">Name...</label>
            <hr>
        </div>
        <div class="mb-3 text-end">
            <label for="floatingPlaintextInput" class="d-block">Private Vaults can only be seen by you</label>
            <input type="checkbox" id="isPrivate"> <label for=""><b>Make Vault Private?</b></label>
        </div>
    </form>
</template>


<style lang="scss" scoped></style>