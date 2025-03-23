<script lang="ts" setup>
import MdiCheckCircle from "virtual:icons/mdi/check-circle";
import MdiClose from "virtual:icons/mdi/close";

withDefaults(
    defineProps<{
        message: string;
        type?: "success" | "error" | "info" | "warning";
    }>(),
    {
        type: "info",
    }
);
</script>

<template>
    <div
        class="fixed bottom-5 right-5 px-5 py-3 bg-white rounded-lg shadow-md z-50 min-w-[300px]"
        :class="type"
    >
        <div class="flex items-center gap-3">
            <MdiCheckCircle v-if="type === 'success'" class="text-green-500" />
            <MdiClose v-if="type === 'error'" class="text-red-500" />
            <div>{{ message }}</div>
        </div>
    </div>
</template>
