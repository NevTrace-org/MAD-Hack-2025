using Qubik.Hackathon.API.DTOs;

namespace Qubik.Hackathon.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string TxId { get; set; }
        public long Tick { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public long? Quantity { get; set; }   
        public DateTime Date { get; set; }
        public Transaction() { }
        public Transaction(TransactionDetail item, long timestamp, int companyId) {
            this.CompanyId = companyId;
            this.TxId = item.TxId;
            this.Tick = item.TickNumber;
            this.From = item.SourceId;
            this.To = item.DestId;
            this.Quantity = item.Amount.Value;
            this.Date = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;

        }
    }
}
