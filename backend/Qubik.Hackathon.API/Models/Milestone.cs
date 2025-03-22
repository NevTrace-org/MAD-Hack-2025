namespace Qubik.Hackathon.API.Models
{
    public class Milestone
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        //public int TransactionId { get; set; }
        public string Name { get; set; }
        public DateTime? ValidatedAt { get; set; }
        public string ValidatorRecipientAddress { get; set; }
        public long ValidationAmount { get;set; }
        public long AmountReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
