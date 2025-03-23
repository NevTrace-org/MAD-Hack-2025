// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
    ssr: false,
    app: {
        head: {
            title: "Quibik | Dashboard",
            htmlAttrs: {
                lang: "es",
            },
            meta: [
                {
                    charset: "utf-8",
                },
                {
                    name: "viewport",
                    content: "width=device-width, initial-scale=1",
                },
                {
                    name: "description",
                    content:
                        "Qubik dashboard for managing funding and resources",
                },
            ],
            link: [
                {
                    rel: "stylesheet",
                    href: "https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap",
                },
            ],
        },
        baseURL: "/",
    },
    compatibilityDate: "2024-11-01",
    css: ["~/assets/main.scss"],
    devtools: { enabled: true },
    modules: ["@nuxtjs/tailwindcss", "unplugin-icons/nuxt", "@pinia/nuxt"],
});
