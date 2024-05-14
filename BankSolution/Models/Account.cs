using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSolution.Models
{
    public class Account
    {
        public int? AccountNumber { get; set; }
        public string? AccountHolderName { get; set; } = string.Empty;
        public double? Balance { get; set; }
        public double? Amount { get; set; }
        public string AccountType {get; set;} =string.Empty;
         [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}