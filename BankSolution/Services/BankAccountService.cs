using BankSolution.Interfaces;
using BankSolution.Models;

namespace BankSolution.Services
{
    public class BankAccountService : IAccountOperationsService
    {
        private readonly IRepository<int, Account> _accountRepository;

        public BankAccountService(IRepository<int, Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account? Deposit(Account account)
        {

            var savingsAccount = _accountRepository.GetAll()?.FirstOrDefault(u => u.UserId == account.UserId && u.AccountType == account.AccountType);
            if (savingsAccount != null)
            {
                savingsAccount.Balance += account.Amount;
                var updateCheck = _accountRepository.Update(savingsAccount);
                if (updateCheck != null)
                    return updateCheck;
            }
            return null;
        }

        public Account? Withdraw(Account account)
        {
            var savingsAccount = _accountRepository.GetAll()?.FirstOrDefault(u => u.UserId == account.UserId && u.AccountType == account.AccountType);
            if (savingsAccount != null)
            {
                if (savingsAccount.Balance >= account.Amount)
                {
                    savingsAccount.Balance -= account.Amount;
                    var updateCheck = _accountRepository.Update(savingsAccount);
                    if (updateCheck != null)
                        return updateCheck;
                }
            }
            return null;
        }
    }
}
