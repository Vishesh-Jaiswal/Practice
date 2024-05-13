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

        public BankingContoller(IAccountOperationsService accountOperationsService)
        {
            _accountOperationsService = accountOperationsService;
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
                var account=_accountOperationsService.Deposit(acc);
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
      
    }
}