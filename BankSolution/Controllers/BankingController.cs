using BankSolution.Interfaces;
using BankSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingContoller : ControllerBase
    {
        private readonly IAccountOperationsService _accountOperationsService;
        private readonly IAccountTransferService _accountTransferService;

        public BankingContoller(IAccountOperationsService accountOperationsService, IAccountTransferService accountTransferService)
        {
            _accountOperationsService = accountOperationsService;
            _accountTransferService=accountTransferService;
        }
        [Route("Withdraw")]
        [HttpPut]
        public ActionResult Withdraw(Account acc)
        {

            string message = "";
            try
            {
                _accountOperationsService.Withdraw(acc);
                if (acc != null)
                {
                    return Ok(acc);
                }
            }
            catch (DbUpdateException)
            {
                message = "Withdraw Failed";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }

        [Route("Deposit")]
        [HttpPut]
        public ActionResult Deposit(Account acc)
        {

            string message = "";
            try
            {
                var account = _accountOperationsService.Deposit(acc);
                if (account != null)
                {
                    return Ok(account);
                }
            }
            catch (DbUpdateException)
            {
                message = "Deposit Failed";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }

        [Route("Transfer")]
        [HttpPut]
        public ActionResult Transfer(int fromUserId, string fromAccountType, int toUserId, string toAccountType, double amount)
        {
            string message = "";
            try
            {
                var account = _accountTransferService.Transfer(fromUserId, fromAccountType, toUserId, toAccountType, amount);
                if (account != null)
                {
                    return Ok(account);
                }
            }
            catch (DbUpdateException)
            {
                message = "Transfer Failed";
            }
            return BadRequest(message);
        }


    }
}