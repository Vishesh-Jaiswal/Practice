using BankSolution.Interfaces;
using BankSolution.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSpotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        private readonly IUserService _userService;

        public BloggerController(IUserService userService)
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
                message = "This User already exists";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }
      
    }
}