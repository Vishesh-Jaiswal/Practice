using BankSolution.Models;
namespace BankSolution.Interfaces
{
    public interface IAccountOperationsService
    {
        public void Deposit(Account account);
        public void Withdraw(Account account);
    }
}
