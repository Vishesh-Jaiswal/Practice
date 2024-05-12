using BankSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Contexts
{
    public class BankSolutionContext : DbContext
    {

        public BankSolutionContext(DbContextOptions options) : base(options)
        {
            Users = Set<User>();
            Accounts = Set<Account>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}