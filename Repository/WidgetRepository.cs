using CRM.Db;
using CRM.Models;
using System.Collections;

namespace CRM.Repository
{
    public class WidgetRepository
    {
        private readonly CrmDbContext _dbContext;
        private readonly WorkDayRepository _workDayRepository;
        private readonly UserDayRepository _userDaysRepository;
        public WidgetRepository(CrmDbContext dbContext)
        {
            _dbContext = dbContext;    
            _workDayRepository = new WorkDayRepository(dbContext);
            _userDaysRepository = new UserDayRepository(dbContext);
        }
        public async Task<ArrayList> GetWidgets(int userId, List<WidgetsIds> widgets)
        {
            var widgetList = new ArrayList();

            if (widgets.Contains(WidgetsIds.WORKING)) {
                var workDaysOfUser = await _workDayRepository.GetWorkDaysOfUser(userId);
                widgetList.Add(new WorkingWidget(workDaysOfUser));
            }

            if (widgets.Contains(WidgetsIds.DAYS))
            {
                var userDays = await _userDaysRepository.GetUserDays(userId);
                widgetList.Add(new DaysWidget(userDays));
            }

            return widgetList;
        }
    }
}
