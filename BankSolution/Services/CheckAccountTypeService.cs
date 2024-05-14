using BankSolution.Interfaces;
using BankSolution.Models;

namespace BankSolution.Services
{
    public class CheckAccountTypeService
    {
        private readonly IRepository<int, Account> _accountRepository;
        public CheckAccountTypeService(IRepository<int, Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account? GetDetails(int? UserId,string? AccountType){
            var savingsAccount = _accountRepository?.GetAll()?.FirstOrDefault(u => u.UserId == UserId && u.AccountType == AccountType);
            if (savingsAccount != null)
                return savingsAccount;
            return null;
        }
        
    }
}