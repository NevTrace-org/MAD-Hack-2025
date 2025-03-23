namespace Qubik.Hackathon.API.DTOs
{
    public class TransactionGroup
    {
        public long TickNumber { get; set; }
        public string Identity { get; set; }
        public List<TransactionItem> Transactions { get; set; }
    }

}
