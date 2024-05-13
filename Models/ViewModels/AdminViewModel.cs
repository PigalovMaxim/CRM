using CRM.Models.Entities;

namespace CRM.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<User> Users { get; set; }
        public List<WorkDayEntity> WorkDays { get; set; }
    }
}
