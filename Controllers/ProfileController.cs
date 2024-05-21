using CRM.Db;
using CRM.Models.Entities;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class ProfileController : Controller
    {
        private readonly WorkDayService _workDaysService;

        public ProfileController(CrmDbContext crmDbContext)
        {
            _workDaysService = new WorkDayService(crmDbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<bool> CreateWorkDay([FromBody] WorkDayEntity workDay)
        {
            bool created = await _workDaysService.CreateWorkDay(workDay);
            return created;
        }
    }
}