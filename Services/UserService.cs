using CRM.Db;
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
    }
}
