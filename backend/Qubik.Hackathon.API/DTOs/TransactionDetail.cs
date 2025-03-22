namespace Qubik.Hackathon.API.DTOs
{
    public class TransactionDetail
    {
        public string SourceId { get; set; }
        public string DestId { get; set; }
        public long? Amount { get; set; }
        public long TickNumber { get; set; }
        public int InputType { get; set; }
        public int InputSize { get; set; }
        public string InputHex { get; set; }
        public string SignatureHex { get; set; }
        public string TxId { get; set; }
    }

}
