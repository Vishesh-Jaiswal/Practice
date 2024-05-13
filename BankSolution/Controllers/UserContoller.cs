using BankSolution.Interfaces;
using BankSolution.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Register")]
        [HttpPost]
        public ActionResult Register(User uers)
        {

            string message = "";
            try
            {
                var user = _userService.Register(uers);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException)
            {
                message = "This user already exists";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }
      
    }
}
