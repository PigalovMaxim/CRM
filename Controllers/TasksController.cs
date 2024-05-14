using CRM.Db;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class TasksController : Controller
    {
        private readonly UserService _userService;

        public TasksController(CrmDbContext crmDbContext)
        {
            _userService = new UserService(crmDbContext);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}