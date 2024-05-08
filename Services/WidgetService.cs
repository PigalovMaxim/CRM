using CRM.Db;
using CRM.Repository;
using System.Collections;

namespace CRM.Services
{
    public class WidgetService
    {
        private WidgetRepository _repository;

        public WidgetService(CrmDbContext dbContext)
        {
            _repository = new WidgetRepository(dbContext);
        }

        public ArrayList GetWidgets(int userId)
        {
            return _repository.GetWidgets(userId);
        }
    }
}
