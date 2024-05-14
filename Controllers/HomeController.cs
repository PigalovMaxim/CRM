using CRM.Db;
using CRM.Models;
using CRM.Models.RequestModels;
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

        [HttpPost]
        public async Task<IActionResult> GetWidgets([FromBody] GetWidgetModel data)
        {
            if (data.Id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            var widgets = await _widgetservice.GetWidgets((int) data.Id, data.WidgetIds);
            return Json(widgets);
        }

        [HttpGet]
        public List<GetWidgetListReturnModel> GetWidgetList()
        {
            return [
                new() {
                    WidgetId = WidgetsIds.WORKING,
                    WidgetName = "Рабочие часы",
                },
                new() {
                    WidgetId = WidgetsIds.DAYS,
                    WidgetName = "Календарь",
                },
            ];
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
