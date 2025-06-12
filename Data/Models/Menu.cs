using System.ComponentModel.DataAnnotations;

namespace eatery_manager_server.Data.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa pozycji jest wymagana")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cena musi być większa od 0")]
        public decimal Price { get; set; }

        [Required]
        public string Ingredients { get; set; } = string.Empty;

        public int Order { get; set; }

        public string Category { get; set; } = string.Empty;

    }

}