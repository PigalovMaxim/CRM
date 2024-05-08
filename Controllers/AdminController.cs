using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
