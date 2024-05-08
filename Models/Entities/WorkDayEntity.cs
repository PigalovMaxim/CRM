namespace CRM.Models.Entities
{
    public class WorkDayEntity
    {
        public int Id { get; set; }
        // Количество рабочих часов за день
        public byte Count { get; set; }
        // Который день
        public DateTime Day { get; set; }
        // Описание рабочего дня
        public string Description { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
