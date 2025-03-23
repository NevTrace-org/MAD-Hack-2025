<script lang="ts" setup>
defineProps<{
    text: string;
}>();
</script>

<template>
    <div>
        <p class="text-primary-800 text-sm">{{ text }}</p>
    </div>
</template>

<style lang="scss" scoped></style>
