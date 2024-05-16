using System.ComponentModel.DataAnnotations;

namespace API_FINAL.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        public string username { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }
    }
}
