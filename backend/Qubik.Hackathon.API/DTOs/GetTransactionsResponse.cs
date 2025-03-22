namespace Qubik.Hackathon.API.DTOs
{
    public class GetTransactionsResponse
    {
        public Pagination Pagination { get; set; }
        public List<TransactionGroup> Transactions { get; set; }

    }

}
