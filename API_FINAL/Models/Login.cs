namespace API_FINAL.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string username { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
