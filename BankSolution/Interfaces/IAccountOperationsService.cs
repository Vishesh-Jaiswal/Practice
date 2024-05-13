using BankSolution.Models;
namespace BankSolution.Interfaces
{
    public interface IAccountOperationsService
    {
        Account? Deposit(Account account);
        Account? Withdraw(Account account);
    }
}
