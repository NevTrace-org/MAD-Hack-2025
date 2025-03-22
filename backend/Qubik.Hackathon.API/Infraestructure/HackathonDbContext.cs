using Microsoft.EntityFrameworkCore;
using Qubik.Hackathon.API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Qubik.Hackathon.API.Data
{
    public class HackathonDbContext : DbContext
    {
        public HackathonDbContext(DbContextOptions<HackathonDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones entre Startup y otras entidades
            modelBuilder.Entity<Company>()
                .HasMany(s => s.Reports)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(s => s.Milestones)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(s => s.Investments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
