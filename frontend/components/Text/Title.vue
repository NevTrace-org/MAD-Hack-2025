<script lang="ts" setup>
defineProps<{
    text: string;
}>();
</script>

<template>
    <div>
        <p class="text-light text-2xl">{{ text }}</p>
    </div>
</template>

<style lang="scss" scoped></style>
