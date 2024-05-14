using CRM.Db;
using CRM.Models;
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

        public async Task<ArrayList> GetWidgets(int userId, List<WidgetsIds> widgets)
        {
            return await _repository.GetWidgets(userId, widgets);
        }
    }
}
