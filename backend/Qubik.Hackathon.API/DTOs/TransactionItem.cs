namespace Qubik.Hackathon.API.DTOs
{
    public class TransactionItem
    {
        public TransactionDetail Transaction { get; set; }
        public long Timestamp { get; set; }
        public bool MoneyFlew { get; set; }
    }
}
