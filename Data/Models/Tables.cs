using System.ComponentModel.DataAnnotations;

namespace eatery_manager_server.Data.Models
{
    public class Tables
    {
        [Key]
        public int TableId { get; set; }

        [Required(ErrorMessage = "Lokalizacja X jest wymagana")]
        public string LocationX { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lokalizacja Y jest wymagana")]
        public string LocationY { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ilość miejsc jest wymagana")]
        public int Capacity { get; set; }

    }
}
