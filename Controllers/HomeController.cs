using CRM.Models;
using CRM.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private WidgetRepository WidgetRepository = new();

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public JsonResult AddWidget(int widgetId)
        {

            return Json(new { test = 3 });
        }

        [HttpGet]
        public JsonResult GetWidgets()
        {
            var widgets = WidgetRepository.GetWidgets();
            return Json(widgets);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
