import { defineStore } from "pinia";
import { ref } from "vue";

export const useToastStore = defineStore("toastStore", () => {
    const show = ref(false);
    const message = ref("");
    const type = ref<"success" | "error" | "info" | "warning">("info");
    const duration = ref(5000);
    const timeoutId = ref<number | null>(null);

    function showToast(
        toastMessage: string,
        toastType: "success" | "error" | "info" | "warning" = "info",
        toastDuration: number = 5000
    ) {
        // Clear any existing timeout
        if (timeoutId.value) {
            clearTimeout(timeoutId.value);
            timeoutId.value = null;
        }

        // Set toast properties
        show.value = true;
        message.value = toastMessage;
        type.value = toastType;
        duration.value = toastDuration;

        // Set auto-hide timeout
        if (toastDuration > 0) {
            timeoutId.value = setTimeout(() => {
                hideToast();
            }, toastDuration) as unknown as number;
        }
    }

    function hideToast() {
        show.value = false;

        if (timeoutId.value) {
            clearTimeout(timeoutId.value);
            timeoutId.value = null;
        }
    }

    return {
        show,
        message,
        type,
        duration,
        timeoutId,
        showToast,
        hideToast,
    };
});
