namespace NamespaceGPT.Data.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required IAction Action { get; set; } 
    }
}
