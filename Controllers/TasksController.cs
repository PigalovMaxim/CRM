using CRM.Db;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _tasksService;

        public TasksController(CrmDbContext crmDbContext)
        {
            _tasksService = new TaskService(crmDbContext);
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _tasksService.GetTasks();
            return View(tasks);
        }
    }
}