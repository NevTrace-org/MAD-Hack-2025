export interface Transaction {
    id: number;
    companyId: number;
    txId: string;
    tick: number;
    from: string;
    to: string;
    quantity: number;
    date: string;
}
