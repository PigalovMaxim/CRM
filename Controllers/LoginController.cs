using CRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserEntity user)
        {
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Hash))
            {
                return NotFound(); 
            }
            return Ok(user.Login);
        }
    }
}
