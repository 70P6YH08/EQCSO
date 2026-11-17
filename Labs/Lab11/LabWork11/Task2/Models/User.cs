namespace Task2.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
