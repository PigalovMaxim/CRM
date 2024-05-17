using CRM.Db;
using CRM.Models.Entities;
using CRM.Models.ViewModels;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly WorkDayService _workDaysService;
        private readonly TaskService _taskService;

        public AdminController(CrmDbContext crmDbContext)
        {
            _userService = new UserService(crmDbContext);
            _workDaysService = new WorkDayService(crmDbContext);
            _taskService = new TaskService(crmDbContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<bool> CreateUser([FromBody] UserEntity userEntity)
        {
            bool created = await _userService.CreateUser(userEntity);
            return created;
        }
        
        public async Task<bool> CreateTask([FromBody] TaskEntity taskEntity)
        {
            bool created = await _taskService.CreateTask(taskEntity);
            return created;
        }

        public async Task<bool> CreateWorkDay([FromBody] WorkDayEntity workDay)
        {
            bool created = await _workDaysService.CreateWorkDay(workDay);
            return created;
        }

        public async Task<IActionResult> GetAdminData(int? id)
        {
            var users = await _userService.GetUsers();
            var selectedUser = users.Find(user => user.Id == id);
            var selectedId = selectedUser == null ? users.ElementAt(0).Id : selectedUser.Id;

            var workDays = await _workDaysService.GetWorkDaysOfUser(selectedId);
            var modelData = new AdminViewModel()
            {
                Users = users,
                WorkDays = workDays,
            };
            return Json(modelData);
        }
    }
}
