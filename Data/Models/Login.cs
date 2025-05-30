using System.ComponentModel.DataAnnotations;

namespace eatery_manager_server.Data.Models
{
    public class Login
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User"; // np. "User" albo "Admin"
    }
}
