import { QubicTransaction } from "@qubic-lib/qubic-ts-library/dist/qubic-types/QubicTransaction.js";

const _baseURL = "https://rpc.qubic.org";

interface RPCStatus {
    lastProcessedTick: {
        tickNumber: number;
        [key: string]: any;
    };
    [key: string]: any;
}

interface TransactionResult {
    transactionId: string;
    targetTick: number;
}

export const useQubikTransaction = () => {
    const sendTransaction = async (
        sourceId: string,
        sourceSeed: string,
        destinationId: string,
        amount: number
    ): Promise<TransactionResult | undefined> => {
        const rpcStatus = await getRPCStatus();
        const currentTick = rpcStatus.tickInfo.tick;

        console.log("Current tick: ", currentTick);

        const targetTick = currentTick + 15;

        console.log("Target tick: ", targetTick);

        const tx = new QubicTransaction()
            .setSourcePublicKey(sourceId)
            .setDestinationPublicKey(destinationId)
            .setAmount(amount)
            .setTick(targetTick);

        await tx.build(sourceSeed);

        const response = await broadcastTransaction(tx);
        const responseData = await response.json();

        if (!response.ok) {
            throw new Error("Failed to broadcast transaction");
        }

        return {
            transactionId: responseData.transactionId,
            targetTick,
        };
    };

    const broadcastTransaction = async (
        transaction: QubicTransaction
    ): Promise<Response> => {
        const encodedTransaction = transaction.encodeTransactionToBase64(
            transaction.getPackageData()
        );

        return await fetch(_baseURL + "/v1/broadcast-transaction", {
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            method: "POST",
            body: JSON.stringify({
                encodedTransaction: encodedTransaction,
            }),
        });
    };

    const getBalance = async (identity: string): Promise<number> => {
        const res = await fetch(`${_baseURL}/v1/balances/${identity}`);
        const data = await res.json();

        return data.balance;
    };

    const getRPCStatus = async (): Promise<RPCStatus> => {
        const res = await fetch(`${_baseURL}/v1/tick-info`);
        const data = await res.json();

        return data;
    };

    return {
        sendTransaction,
        broadcastTransaction,
        getRPCStatus,
        getBalance,
    };
};
