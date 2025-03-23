<script lang="ts" setup>
const router = useRouter();

onMounted(async () => {
    setTimeout(async () => {
        router.push("/dashboard");
    }, 2000);
});
</script>

<template>
    <div class="flex justify-center items-center h-screen w-full">
        <Loader />
    </div>
</template>

<style lang="scss" scoped>
/* Removed SCSS as we're using Tailwind classes now */
</style>
