using CRM.Models.Entities;

namespace CRM.Models
{
    public class WorkingWidget : BaseWidget
    {
        public int TotalHours { get; set; }
        public int PlanHours { get; set; }
        public int WorkedToday { get; set; }

        public WorkingWidget(List<WorkDayEntity> workDaysOfUser) : base(WidgetsIds.WORKING, "Рабочие часы")
        {
            var currentDate = DateTime.Now;
            var workDaysOfCurrentMonth = workDaysOfUser
                .Where(wd => wd.Day.Month == currentDate.Month && wd.Day.Year == currentDate.Year)
                .ToList();
            var hours = workDaysOfCurrentMonth.Sum(wd => wd.Count);
        
            TotalHours = hours;
            PlanHours = 168;
            //TODO
            WorkedToday = 3;
        } 
    }
}
