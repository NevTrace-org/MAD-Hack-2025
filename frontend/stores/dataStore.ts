import type { Milestone } from "~/types/api/Milestone";
import type { Startup } from "~/types/api/Startup";
import type { MilestoneRow } from "~/types/MilestoneRow";

export const useDataStore = defineStore("dataStore", () => {
    const addresses: string[] = [
        "YMUBZAGQKSQLMGAEYCAEZVKEFZZBIEFHKTOQTZQYVAQBPIZHXPMMFGAHCJVH",
        "EPKIJRYARRLPQDXKGONDRDLGSNBDWKYNYQUAVYEFABOHWCZTWENOEDCARDYH",
    ];
    const milestoneRows = ref<MilestoneRow[]>([]);

    const fetchData = async () => {
        const data = await Promise.all(
            addresses.map((address) =>
                fetch(
                    `https://5re6ru05bd.execute-api.eu-west-3.amazonaws.com/Prod/api/company/${address}`
                ).then((res) => res.json())
            )
        );

        console.log(data);

        // Sort milestones by id for each startup
        const processedData = data.map((startup) => {
            if (startup.milestones && Array.isArray(startup.milestones)) {
                startup.milestones.sort(
                    (a: Milestone, b: Milestone) => a.id - b.id
                );
            }
            return startup;
        });

        processedData.forEach((startup: Startup) => {
            if (startup.milestones && Array.isArray(startup.milestones)) {
                startup.milestones.forEach((milestone: Milestone) => {
                    milestoneRows.value.push({
                        id: `${startup.id}-${milestone.id}`,
                        startupId: startup.id,
                        startupName: startup.name,
                        startupLogoUrl: startup.imageUrl,
                        startupAddress: startup.address,
                        startupImageUrl: startup.imageUrl,
                        investorIdentity: startup.investorIdentity,
                        investorSeed: startup.investorSeed,
                        milestoneId: milestone.id,
                        milestoneName: milestone.name,
                        validatedAt: milestone.validatedAt,
                        validatorRecipientAddress:
                            milestone.validatorRecipientAddress,
                        validationAmount: milestone.validationAmount,
                        releaseDate: milestone.releaseDate,
                    });
                });
            }
        });
    };

    return {
        milestoneRows,
        fetchData,
    };
});
