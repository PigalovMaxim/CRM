namespace CRM.Models
{
    public enum WidgetsIds
    {
        WORKING,
        DAYS
    }
    public class BaseWidget
    {
        public WidgetsIds TypeId { get; set; }
        public string Name { get; set; }

        public BaseWidget(WidgetsIds typeId, string name)
        {
            TypeId = typeId;
            Name = name;
        }
    }
}
