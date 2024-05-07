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
        public DaysWidget(List<DaysTypes> days) : base(WidgetsIds.DAYS, "Рабочие дни")
        {
            Days = days;
        }
    }
}
