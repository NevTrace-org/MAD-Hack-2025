import type { Milestone } from "./Milestone";
import type { Transaction } from "./Transaction";

export interface Startup {
    id: number;
    name: string;
    address: string;
    imageUrl: string;
    reports: any[] | null;
    investorIdentity: string;
    investorSeed: string;
    milestones: Milestone[];
    investments: any[];
    transactions: Transaction[];
}
