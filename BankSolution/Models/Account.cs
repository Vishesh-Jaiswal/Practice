using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSolution.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountHolderName { get; set; } = string.Empty;
        public double? Balance { get; set; }
        [Key, Column(Order = 0)]
        public string AccountType {get; set;} =string.Empty;
        [Key, ForeignKey("User"), Column(Order =1)]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
