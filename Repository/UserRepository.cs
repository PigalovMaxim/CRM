using CRM.Db;
using Microsoft.EntityFrameworkCore;

namespace CRM.Repository
{
    public class UserRepository
    {
        private readonly CrmDbContext _dbContext;

        public UserRepository(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> Login(string login, string hash)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login && u.Hash == hash);
            if (user == null)
            {
                return null;
            }
            return user.Id;
        }
    }
}
