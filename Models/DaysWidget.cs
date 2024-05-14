using CRM.Models.Entities;

namespace CRM.Models
{
    public enum DaysTypes
    {
        WORKING,
        SKIP,
        TIME_OFF,
        HOLIDAY,
        NONE,
    }
    public class DaysWidget : BaseWidget
    {
        public List<DaysTypes> Days { get; set; }
        public DaysWidget(List<UserDayEntity> userDays) : base(WidgetsIds.DAYS, "Рабочие дни")
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            List<UserDayEntity> currentMonthDays = userDays.Where(day => day.Day.Month == currentMonth && day.Day.Year == currentYear).ToList();
            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            List<DaysTypes> workingWeek = [
                DaysTypes.WORKING,
                DaysTypes.WORKING,
                DaysTypes.WORKING,
                DaysTypes.WORKING,
                DaysTypes.WORKING,
                DaysTypes.SKIP,
                DaysTypes.SKIP,
            ];

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<DaysTypes> days = new(new DaysTypes[daysInMonth]);
            int numberOfMonthStart = (int)startOfMonth.DayOfWeek - 1;

            for (int i = 0; i < daysInMonth; i++)
            {
                days[i] = workingWeek[(i + numberOfMonthStart) % 7];
                for (int j = 0; j < currentMonthDays.Count; j++)
                {
                    int userDay = currentMonthDays.ElementAt(j).Day.Day;
                    if (userDay == i + 1)
                    {
                        days[i] = currentMonthDays[j].DayType;
                    }
                }
            }

            Days = days;
        }
    }
}
