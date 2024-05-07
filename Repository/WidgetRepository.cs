using CRM.Models;
using System.Collections;

namespace CRM.Repository
{
    public class WidgetRepository
    {
        public ArrayList GetWidgets()
        {
            var widgets = new ArrayList
            {
                new WorkingWidget(20, 100, 3),
                new DaysWidget(new List<DaysTypes>{
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.SKIP,
                    DaysTypes.SKIP,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.SKIP,
                    DaysTypes.SKIP,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.WORKING,
                    DaysTypes.TIME_OFF,
                    DaysTypes.WORKING,
                    DaysTypes.SKIP,
                    DaysTypes.SKIP,
                    DaysTypes.HOLIDAY,
                    DaysTypes.HOLIDAY,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                    DaysTypes.NONE,
                })
            };

            return widgets;
        }
    }
}
