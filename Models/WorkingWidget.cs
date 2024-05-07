namespace CRM.Models
{
    public class WorkingWidget : BaseWidget
    {
        public int totalHours { get; set; }
        public int planHours { get; set; }
        public int workedToday { get; set; }
        public WorkingWidget(int totalHours, int planHours, int workedToday) : base(WidgetsIds.WORKING, "Рабочие часы")
        {
            this.totalHours = totalHours;
            this.planHours = planHours;
            this.workedToday = workedToday;
        }
    }
}
