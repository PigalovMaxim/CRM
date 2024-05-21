using CRM.Db;
using CRM.Models;
using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
                .Include(t => t.Creator)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> TakeTask(int userId, int taskId)
        {
            try
            {
                await _dbContext.Tasks
                .Where(t => t.Id == taskId)
                .ExecuteUpdateAsync(t =>
                    t.SetProperty(r => r.ExecutorId, userId)
                     .SetProperty(r => r.StartedDate, DateTime.Now.ToUniversalTime()));
            } catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> StopTask(int userId, int taskId)
        {
            try
            {
                var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
                if (task == null || task.ExecutorId != userId) return false;

                task.ExecutorId = null;
                task.WastedHours = (float) Math.Round((DateTime.Now - task.StartedDate).TotalHours - 4 + task.WastedHours);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
