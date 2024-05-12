using BankSolution.Models;

namespace BankSolution.Interfaces
{
    public interface IAccountOperationsService
    {
        public void Deposit(double amount);
        public void Withdraw(double amount);
    }
}