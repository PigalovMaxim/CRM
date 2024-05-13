using CRM.Db;
using CRM.Repository;

namespace CRM.Services
{
    public class UserDayService
    {
        private UserDayRepository _repository;

        public UserDayService(CrmDbContext dbContext)
        {
            _repository = new UserDayRepository(dbContext);
        }
    }
}
