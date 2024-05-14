namespace CRM.Models.RequestModels
{
    public class GetWidgetModel
    {
        public int? Id { get; set; }
        public List<WidgetsIds> WidgetIds { get; set; }
    }
}
