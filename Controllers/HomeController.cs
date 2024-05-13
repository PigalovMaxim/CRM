using CRM.Db;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly WidgetService _widgetservice;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, CrmDbContext dbContext)
        {
            _logger = logger;
            _config = config;
            _widgetservice = new WidgetService(dbContext);
        }

        [HttpGet]
        public JsonResult AddWidget(int widgetId)
        {

            return Json(new { test = 3 });
        }

        [HttpGet]
        public async Task<IActionResult> GetWidgets(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var widgets = await _widgetservice.GetWidgets((int) id);
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
