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
            return await _repository.GetTasks();
        }
    }
}
