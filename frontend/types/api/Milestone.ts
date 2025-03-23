export interface Milestone {
    id: number;
    companyId: number;
    name: string;
    validatedAt: string | null;
    validatorRecipientAddress: string;
    validationAmount: number;
    releaseDate: string | null;
}
