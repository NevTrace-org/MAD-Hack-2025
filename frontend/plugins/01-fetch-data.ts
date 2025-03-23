export default defineNuxtPlugin((nuxtApp) => {
    const dataStore = useDataStore();

    dataStore.fetchData();
});
