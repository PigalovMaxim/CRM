using CRM.Db;
using CRM.Models;
using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Repository
{
    public class TaskRepository
    {
        private readonly CrmDbContext _dbContext;

        public TaskRepository(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateTask(TaskEntity task)
        {
            try
            {
                await _dbContext.Tasks.AddAsync(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<TaskEntity>> GetTasks()
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
