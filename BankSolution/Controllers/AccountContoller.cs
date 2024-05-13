using BankSolution.Interfaces;
using BankSolution.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountContoller : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountContoller(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Route("Create Account")]
        [HttpPost]
        public ActionResult Register(Account acc)
        {

            string message = "";
            try
            {
                var account = _accountService.Create(acc);
                if (account != null)
                {
                    return Ok(account);
                }
            }
            catch (DbUpdateException)
            {
                message = "No Such User Exists";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }
      
    }
}
