using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
