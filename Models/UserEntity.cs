namespace CRM.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }
}
