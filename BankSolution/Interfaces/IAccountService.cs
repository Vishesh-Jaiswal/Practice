using BankSolution.Models;

namespace BankSolution.Interfaces
{
    public interface IAccountService
    {
        Account? Create(Account account);
    }
}