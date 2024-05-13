using System.ComponentModel.DataAnnotations;

namespace BankSolution.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public virtual Account? Account { get; set; }
    }
}
