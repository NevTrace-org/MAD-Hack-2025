namespace Qubik.Hackathon.API.Models
{
    public class Milestone
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime? PassDate { get; set; }
        public string ValidatorRecipientAddress { get; set; }
        public long ValidationAmount { get;set; }
    }
}
