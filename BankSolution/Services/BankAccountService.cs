using BankSolution.Interfaces;
using BankSolution.Models;
using BankSolution.Services;

namespace BankSolution.Services
{
    public class BankAccountService : IAccountOperationsService
    {
        private readonly CheckAccountTypeService _checkAccountTypeService;
        private readonly ChangeBalanceService _changeBalanceService;
        public BankAccountService(ChangeBalanceService changeBalanceService, CheckAccountTypeService checkAccountTypeService)
        {
            _checkAccountTypeService = checkAccountTypeService;
            _changeBalanceService = changeBalanceService;

        }
        public Account? Deposit(Account account)
        {
            var savingsAccount = _checkAccountTypeService.GetDetails(account.UserId,account.AccountType);
            if (savingsAccount != null)
            {
                if(savingsAccount.Balance==null)
                    savingsAccount.Balance=0;
                savingsAccount.Balance += account.Amount;
                return _changeBalanceService.UpdateBalance(savingsAccount);
            }
            return null;
        }

        public Account? Withdraw(Account account)
        {
            var savingsAccount = _checkAccountTypeService.GetDetails(account.UserId,account.AccountType);
            if (savingsAccount != null)
            {
                if (savingsAccount.Balance >= account.Amount)
                {
                    savingsAccount.Balance -= account.Amount;
                    var updateCheck = _changeBalanceService.UpdateBalance(savingsAccount);
                    if (updateCheck != null)
                        return updateCheck;
                }
            }
            return null;
        }
    }
}