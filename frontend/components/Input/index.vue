<script lang="ts" setup>
import MdiEnvelop from "virtual:icons/mdi/envelope-outline";
import MdiEyeOutline from "virtual:icons/mdi/eye-outline";
import MdiEyeOffOutline from "virtual:icons/mdi/eye-off-outline";

const input = defineModel<string | number>({ required: true });

const props = withDefaults(
    defineProps<{
        type?: "number" | "text" | "password" | "email" | "tel" | "url";
        maxlength?: string;
        placeholder?: string;
        validationText?: string;
        disabled?: boolean;
    }>(),
    {
        type: "text",
        maxlength: "79",
        placeholder: "",
        validationText: "",
        disabled: false,
    }
);

const showPassword = ref<boolean>(false);

const inputType = computed(() =>
    props.type === "password"
        ? showPassword.value
            ? "text"
            : "password"
        : props.type
);

const togglePasswordVisibility = () => {
    showPassword.value = !showPassword.value;
};
</script>

<template>
    <div>
        <div class="relative">
            <input
                autocomplete="off"
                autocorrect="off"
                :type="inputType"
                minlength="1"
                :maxlength="maxlength"
                spellcheck="false"
                :placeholder="placeholder"
                v-model="input"
                :disabled="disabled"
                class="no-arrows basis-2/3 outline-none bg-secondary-200 text-light w-full border border-secondary-100 rounded-lg focus:border-secondary-100 py-4 px-6"
            />
            <MdiEnvelop
                v-if="type === 'email'"
                class="absolute right-2 top-1/2 transform -translate-y-1/2 text-primary-900"
            />
            <MdiEyeOutline
                v-if="type === 'password' && showPassword"
                @click="togglePasswordVisibility"
                class="absolute right-2 top-1/2 transform -translate-y-1/2 text-primary-900"
            />
            <MdiEyeOffOutline
                v-if="type === 'password' && !showPassword"
                @click="togglePasswordVisibility"
                class="absolute right-2 top-1/2 transform -translate-y-1/2 text-primary-900"
            />
        </div>
        <span v-if="validationText" class="text-xs text-red-500">{{
            validationText
        }}</span>
    </div>
</template>

<style lang="scss" scoped></style>
