namespace Qubik.Hackathon.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Quantity { get; set; }   
    }
}
