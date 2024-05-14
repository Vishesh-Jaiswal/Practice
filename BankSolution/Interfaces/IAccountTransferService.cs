using BankSolution.Models;

namespace BankSolution.Interfaces
{
    public interface IAccountTransferService
    {
        Account? Transfer(int fromUserId, string fromAccountType, int toUserId, string toAccountType, double amount);
    }
}