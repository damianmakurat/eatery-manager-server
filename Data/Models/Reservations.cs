using System.ComponentModel.DataAnnotations;

namespace eatery_manager_server.Data.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationID { get; set; } // Klucz główny, powinien być automatycznie generowany

        [Required]
        public string Name { get; set; } = string.Empty; // Initialize with a default value

        [Required]
        public string Surname { get; set; } = string.Empty;
    }
}
