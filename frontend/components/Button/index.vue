<script lang="ts" setup>
defineProps<{
    text: string;
    disabled?: boolean;
    loading?: boolean;
}>();

const isClicked = ref(false);

const handleClick = () => {
    isClicked.value = !isClicked.value;

    setTimeout(() => {
        isClicked.value = false;
    }, 150);
};
</script>

<template>
    <button
        :class="[
            ' text-dark text-sm font-semibold px-12 py-3.5  rounded-lg transition-all duration-150 ',
            isClicked ? 'transform scale-95' : 'w-96',
            disabled
                ? 'bg-primary-900 cursor-not-allowed'
                : 'bg-primary hover:bg-primary-600 cursor-pointer',
        ]"
        :disabled="disabled"
        :loading="loading"
        @click="handleClick"
    >
        <Loader v-if="loading" />
        {{ !loading ? text : "" }}
    </button>
</template>

<style lang="scss" scoped></style>
