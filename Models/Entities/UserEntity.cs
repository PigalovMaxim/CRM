namespace CRM.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }
}
