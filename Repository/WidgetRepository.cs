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
        public async Task<ArrayList> GetWidgets(int userId)
        {
            var workDaysOfUser = await _workDayRepository.GetWorkDaysOfUser(userId);
            var userDays = await _userDaysRepository.GetUserDays(userId);

            var widgets = new ArrayList
            {
                new WorkingWidget(workDaysOfUser),
                new DaysWidget(userDays),
            };

            return widgets;
        }
    }
}
