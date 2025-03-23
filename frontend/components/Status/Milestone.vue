<script lang="ts" setup>
defineProps<{
    validated: boolean;
}>();
</script>

<template>
    <div class="w-1.5 h-1.5 relative mr-2">
        <div v-if="validated" class="w-2 h-2 bg-emerald-300 rounded"></div>
        <div v-else class="w-2 h-2 bg-orange-300 rounded"></div>
    </div>
    <div v-if="validated" class="text-zinc-100 text-xs">Completed</div>
    <div v-else class="text-zinc-100 text-xs">Pending</div>
</template>

<style lang="scss" scoped></style>
