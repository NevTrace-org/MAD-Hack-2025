Qubik Smart Contract (HM25.h deployed for Challenge 2)

The developed smart contract is a first version, which allows registering the last milestone achieved in Qubik and reading that information.

Once this version was deployed, the goal was to integrate it from the frontend, where we encountered limitations due to the unavailability of the v2 API, lack of documentation, etc.

For that reason, we decided to integrate on mainnet and simulate the logic to be implemented in the smart contract through transactions.

As an evolution, we propose the following:

Extend the functionality of this smart contract to store all the necessary information to implement automatic milestone validation and payments.

Refactor the frontend to use this smart contract instead of the contingency solution adopted for the hackathon on mainnet.

Create an escrow smart contract that allows the investor to deposit funds at the beginning of the process, once the milestones to be achieved have been defined and agreed upon, and establish mechanisms for automatic payment through multisig: a. If both the investor and the startup agree on the achieved milestone and the payment to be made, both will sign the transaction. b. If there is a dispute, Qubik will act as a mediator. Both parties will provide the necessary information to analyze the case, and based on this, Qubik will facilitate the payment to the startup or the refund to the investor, through multisig with the corresponding party.

Create a set of smart contracts as an oracle to assist in this process by retrieving real-world information for the smart contract to make automated decisions.
