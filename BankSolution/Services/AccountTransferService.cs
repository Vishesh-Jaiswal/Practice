using BankSolution.Interfaces;
using BankSolution.Models;

namespace BankSolution.Services
{
    public class AccountTransferService : IAccountTransferService
    {
        private readonly CheckAccountTypeService _checkAccountTypeService;
        private readonly BankAccountService _bankAccountService;

        public AccountTransferService(BankAccountService bankAccountService,
            CheckAccountTypeService checkAccountTypeService)
        {
            _bankAccountService = bankAccountService;
            _checkAccountTypeService = checkAccountTypeService;
        }

        public Account? Transfer(int fromUserId, string fromAccountType, int toUserId, string toAccountType, double amount)
        {
            var fromAcc = _checkAccountTypeService.GetDetails(fromUserId, fromAccountType);
            var toAcc = _checkAccountTypeService.GetDetails(toUserId, toAccountType);

            if (fromAcc != null && toAcc != null)
            {
                fromAcc.Amount=amount;
                toAcc.Amount=amount;
                var result1 = _bankAccountService.Withdraw(fromAcc);
                var result2 = _bankAccountService.Deposit(toAcc);
                    return toAcc;
            }
            return null;
        }
    }
}