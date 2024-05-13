using CRM.Db;
using CRM.Models;
using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Repository
{
    public class UserDayRepository
    {
        private readonly CrmDbContext _dbContext;

        public UserDayRepository(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserDayEntity>> GetUserDays(int userId)
        {
            var userDays = await _dbContext.UserDays
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return userDays;
        }
    }
}
