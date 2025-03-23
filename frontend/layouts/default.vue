<script lang="ts" setup></script>

<template>
    <div class="flex flex-col min-h-screen">
        <Header class="max-w-screen-lg mx-auto w-full" />
        <div class="flex-1">
            <div class="pt-10 pb-32 max-w-screen-lg mx-auto w-full">
                <slot />
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped></style>
