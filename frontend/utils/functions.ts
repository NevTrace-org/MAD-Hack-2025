/**
 * Transforms a datetime into Spanish short date format (DD/MM/YYYY)
 * @param date The date to format
 * @returns Formatted date string in DD/MM/YYYY format or empty string if invalid date
 */
export function formatDateToSpanishShort(date: Date | string | number): string {
    try {
        const dateObject = date instanceof Date ? date : new Date(date);

        // Check if date is valid
        if (isNaN(dateObject.getTime())) {
            return "";
        }

        const day = dateObject.getDate().toString().padStart(2, "0");
        const month = (dateObject.getMonth() + 1).toString().padStart(2, "0");
        const year = dateObject.getFullYear();

        return `${day}/${month}/${year}`;
    } catch (error) {
        console.error("Error formatting date:", error);
        return "";
    }
}
