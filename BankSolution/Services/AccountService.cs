using BankSolution.Interfaces;
using BankSolution.Models;

namespace BankSolution.Services
{
    public class AccountService:IAccountService
    {
        private readonly IRepository<int, Account> _accountRepository;
        public AccountService(IRepository<int, Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account? Create(Account account)
        {
            var result = _accountRepository.Add(account);
            if (result != null)
            {
                return account;
            }
            return null;
        }
    }
}
