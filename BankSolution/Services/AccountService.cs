using BankSolution.Interfaces;
using BankSolution.Models;
//comment
namespace BankSolution.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<int, Account> _accountRepository;
        private readonly IAccountNumberGenerator _accountNumberGenerator;

        public AccountService(IRepository<int, Account> accountRepository, IAccountNumberGenerator accountNumberGenerator)
        {
            _accountRepository = accountRepository;
            _accountNumberGenerator = accountNumberGenerator;
        }

        public Account? Create(Account account)
        {
            account.AccountNumber = DetermineAccountNumber(account.UserId);

            var result = _accountRepository.Add(account);
            if (result != null)
            {
                return account;
            }
            return null;
        }

        private int? DetermineAccountNumber(int? userId)
        {
            var existingAccount = _accountRepository?.GetAll()?.FirstOrDefault(a => a.UserId == userId);
            return existingAccount?.AccountNumber ?? _accountNumberGenerator.GenerateAccountNumber();
        }
    }
}
