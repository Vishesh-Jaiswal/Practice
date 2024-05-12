using System.ComponentModel.DataAnnotations;

namespace BankSolution.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Account? Account { get; set; }
    }
}