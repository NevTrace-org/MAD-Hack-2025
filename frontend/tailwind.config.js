/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./components/**/*.{js,vue,ts}",
        "./layouts/**/*.vue",
        "./pages/**/*.vue",
        "./plugins/**/*.{js,ts}",
        "./app.vue",
        "./error.vue",
    ],
    theme: {
        extend: {
            colors: {
                primary: {
                    DEFAULT: "#FFFFFF",
                    50: "#FFFFFF",
                    100: "#FFFFFF",
                    200: "#FFFFFF",
                    300: "#FFFFFF",
                    400: "#FFFFFF",
                    500: "#FFFFFF",
                    600: "#E3E3E3",
                    700: "#C7C7C7",
                    800: "#ABABAB",
                    900: "#8F8F8F",
                    950: "#818181",
                },
                secondary: {
                    DEFAULT: "#000000",
                    50: "#5C5C5C",
                    100: "#525252",
                    200: "#3D3D3D",
                    300: "#292929",
                    400: "#141414",
                    500: "#000000",
                    600: "#000000",
                    700: "#000000",
                    800: "#000000",
                    900: "#000000",
                    950: "#000000",
                },
                light: "#FFFFFF",
                dark: "#121212",
                medium: "#888888",
            },
            fontFamily: {
                h: ["Pally", "sans"],
                p: ["Open Sans", "sans-serif"],
            },
        },
    },
    plugins: [],
};
