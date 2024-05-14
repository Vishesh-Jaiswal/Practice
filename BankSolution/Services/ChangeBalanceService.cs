using BankSolution.Interfaces;
using BankSolution.Models;

namespace BankSolution.Services
{
    public class ChangeBalanceService
    {
        private readonly IRepository<int, Account> _accountRepository;
        public ChangeBalanceService(IRepository<int, Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account? UpdateBalance(Account account)
        {
            var updateCheck = _accountRepository.Update(account);
            if (updateCheck != null)
                return updateCheck;
            return null;
        }
    }

}