using CRM.Db;
using CRM.Models.Entities;
using CRM.Repository;

namespace CRM.Services
{
    public class TaskService
    {
        private TaskRepository _repository;

        public TaskService(CrmDbContext dbContext)
        {
            _repository = new TaskRepository(dbContext);
        }

        public async Task<bool> CreateTask(TaskEntity task)
        {
            return await _repository.CreateTask(task);
        }

        public async Task<List<TaskEntity>> GetTasks()
        {
            var tasks = await _repository.GetTasks();
            return tasks.OrderByDescending(task => task.ExecutorId != null).ThenBy(task => task.Id).ToList();
        }

        public async Task<bool> TakeTask(int userId, int taskId)
        {
            return await _repository.TakeTask(userId, taskId);
        }

        public async Task<bool> StopTask(int userId, int taskId)
        {
            return await _repository.StopTask(userId, taskId);
        }
    }
}
