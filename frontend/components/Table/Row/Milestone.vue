<script lang="ts" setup>
import MdiCheckCircle from "virtual:icons/mdi/check-circle";
import type { MilestoneRow } from "~/types/MilestoneRow";

const props = defineProps<{
    data: MilestoneRow;
}>();

const { getRPCStatus, sendTransaction } = useQubikTransaction();
const toastStore = useToastStore();

const isReleased = ref<boolean>(false);
const releaseDate = ref<string>("");

const handleReleaseBudget = async () => {
    try {
        await sendTransaction(
            props.data.investorIdentity,
            props.data.investorSeed,
            props.data.startupAddress,
            props.data.validationAmount
        );

        isReleased.value = true;
        releaseDate.value = formatDateToSpanishShort(new Date().toISOString());

        toastStore.showToast("Confirmed transaction", "success", 4000);
    } catch (error) {
        console.error(error);
        toastStore.showToast("Error sending transaction", "error", 4000);
        return;
    }
};

onMounted(() => {
    getRPCStatus();
});
</script>

<template>
    <div class="grid grid-cols-6 gap-6 px-4 py-2">
        <!-- Columna 1: Startup con imagen y nombre -->
        <div class="flex items-center gap-2">
            <div class="w-9 h-9 relative">
                <img
                    class="w-8 h-8 rounded-full"
                    :src="data.startupLogoUrl"
                    alt="Startup logo"
                />
            </div>
            <TableRowText :text="data.startupName" class="font-semibold" />
        </div>

        <!-- Columna 2: Milestone -->
        <div class="flex items-center">
            <TableRowText :text="data.milestoneName" class="font-semibold" />
        </div>

        <!-- Columna 3: Status -->
        <div class="flex items-center">
            <StatusMilestone :validated="!!data.validatedAt" />
        </div>

        <!-- Columna 4: Validated Date -->
        <div class="flex items-center">
            <TableRowText
                :text="
                    data.validatedAt
                        ? formatDateToSpanishShort(data.validatedAt)
                        : '-'
                "
            />
        </div>

        <!-- Columna 5: Released Date -->
        <div class="flex items-center">
            <TableRowText
                :text="
                    data.releaseDate
                        ? formatDateToSpanishShort(data.releaseDate)
                        : !!releaseDate
                        ? releaseDate
                        : '-'
                "
            />
        </div>

        <!-- Columna 6: Actions -->
        <div class="flex items-center">
            <Button
                v-if="!data.releaseDate && !isReleased"
                text="Release budget"
                :disabled="!data.validatedAt || isReleased"
                @click="handleReleaseBudget()"
            />
            <div v-else class="flex items-center gap-2 w-40">
                <MdiCheckCircle class="text-green-500" />
                <TableRowText text="Funded" />
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped></style>
