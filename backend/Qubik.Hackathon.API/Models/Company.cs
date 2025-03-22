﻿namespace Qubik.Hackathon.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }           
        public ICollection<Report> Reports { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Investment> Investments { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
