using CRM.Db;
using CRM.Models;
using CRM.Models.Entities;
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

        public async Task<UserEntity?> Login(string login, string hash)
        {
            var user = await _dbContext.Users
                .Include(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login && u.Hash == hash);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> CreateUser(UserEntity user)
        {
            try
            {
                user.RoleId = 1;
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Select(u => new User()
                {
                    Id = u.Id,
                    Login = u.Login,
                })
                .ToListAsync();
        }
    }
}
