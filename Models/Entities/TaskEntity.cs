namespace CRM.Models.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float WastedHours { get; set; }
        public float Hours { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CreatorId { get; set; }
        public UserEntity Creator { get; set; }

        public int ExecutorId { get; set; }
        public UserEntity Executor { get; set; }
    }
}
