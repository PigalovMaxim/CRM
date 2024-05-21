namespace CRM.Models.Entities
{
    public enum WidgetsIds
    {
        USER,
        ADMIN
    }

    public class RoleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
