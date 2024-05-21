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

        [HttpGet]
        public async Task<bool> TakeTask(int userId, int taskId)
        {
            return await _tasksService.TakeTask(userId, taskId);
        }

        [HttpGet]
        public async Task<bool> StopTask(int userId, int taskId)
        {
            return await _tasksService.StopTask(userId, taskId);
        }
    }
}