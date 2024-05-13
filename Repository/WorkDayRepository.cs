using CRM.Db;
using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Repository
{
    public class WorkDayRepository
    {
        private readonly CrmDbContext _dbContext;
        public WorkDayRepository(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WorkDayEntity>> GetWorkDaysOfUser(int userId)
        {
            return await _dbContext
                .WorkDays
                .AsNoTracking()
                .Where(wd => wd.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> CreateWorkDay(WorkDayEntity workDay)
        {
            try
            {
                await _dbContext.WorkDays.AddAsync(workDay);
                await _dbContext.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
