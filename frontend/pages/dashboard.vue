<script lang="ts" setup>
const dataStore = useDataStore();
</script>

<template>
    <div>
        <TextTitle text="Milestone list" class="mb-10" />

        <div
            class="w-full flex flex-col items-center bg-secondary-300 rounded-md py-4"
        >
            <TableRowMilestone
                v-for="(data, index) in dataStore.milestoneRows"
                :key="index"
                :data="data"
                class="grid grid-cols-6 gap-6 px-4 py-2 border-b border-secondary-200"
            />
        </div>
    </div>
</template>

<style lang="scss" scoped></style>
