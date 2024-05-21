using CRM.Db;
using CRM.Models.Entities;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _service;

        public LoginController(CrmDbContext crmDbContext) {
            _service = new UserService(crmDbContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserEntity user)
        {
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Hash))
            {
                return NotFound(); 
            }
            var userResult = await _service.Login(user.Login, user.Hash);
            if(userResult == null)
            {
                return BadRequest("Пользователь с таким именем не найден");
            }
            return Ok(new {
                Id = userResult.Id,
                Role = userResult.Role,
            });
        }
    }
}
