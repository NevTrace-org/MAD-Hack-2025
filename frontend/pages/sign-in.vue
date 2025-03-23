<script lang="ts" setup>
definePageMeta({
    layout: "sign-in",
});

const router = useRouter();

const email = ref("");
const password = ref("");

const signIn = () => {
    router.push("/");
};
</script>

<template>
    <div class="py-12 px-8 bg-secondary-300 rounded-lg">
        <div class="flex justify-center mb-4 h-16">
            <img src="/images/logo.png" alt="Qubik logo" />
        </div>

        <TextTitle text="Welcome back!" class="text-center mb-2" />
        <TextLabel
            text="Let's build something great"
            class="text-center mb-10"
        />

        <Input v-model="email" type="email" placeholder="Email" class="mt-4" />
        <Input
            v-model="password"
            type="password"
            placeholder="Password"
            class="mt-4"
        />

        <div class="text-center">
            <Button text="Sign In" class="mt-12" @click="signIn()" />
        </div>

        <TextLabel text="Forgot your password?" class="text-right mt-4" />
    </div>
</template>

<style lang="scss" scoped></style>
