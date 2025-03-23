<script setup lang="ts">
const toastStore = useToastStore();
</script>

<template>
    <div>
        <NuxtLayout>
            <NuxtPage />

            <Transition name="toast">
                <Toast
                    v-if="toastStore.show"
                    :message="toastStore.message"
                    :type="toastStore.type"
                    :duration="toastStore.duration"
                />
            </Transition>
        </NuxtLayout>
    </div>
</template>
