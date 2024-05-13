namespace CRM.Models.Entities
{
    public class UserDayEntity
    {
        public int Id { get; set; }
        public DaysTypes DayType { get; set; }
        public DateTime Day { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
