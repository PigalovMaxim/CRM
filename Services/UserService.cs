using CRM.Db;
using CRM.Models;
using CRM.Models.Entities;
using CRM.Repository;

namespace CRM.Services
{
    public class UserService
    {
        private UserRepository _repository;

        public UserService(CrmDbContext dbContext)
        {
            _repository = new UserRepository(dbContext);
        }

        public async Task<int?> Login(string login, string hash)
        {
            return await _repository.Login(login, hash);
        }

        public async Task<bool> CreateUser(UserEntity user)
        {
            return await _repository.CreateUser(user);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _repository.GetUsers();
        }
    }
}
