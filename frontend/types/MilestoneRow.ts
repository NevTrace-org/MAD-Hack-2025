export interface MilestoneRow {
    id: string; // Composite ID from startup and milestone
    startupId: number;
    startupName: string;
    startupLogoUrl: string;
    startupAddress: string;
    startupImageUrl: string;
    investorIdentity: string;
    investorSeed: string;
    milestoneId: number;
    milestoneName: string;
    validatedAt: string | null;
    validatorRecipientAddress: string;
    validationAmount: number;
    releaseDate: string | null;
}
