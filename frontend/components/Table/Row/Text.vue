<script lang="ts" setup>
defineProps<{
    text: string;
}>();
</script>

<template>
    <div>
        <p class="text-primary text-xs">
            {{ text }}
        </p>
    </div>
</template>

<style lang="scss" scoped></style>
