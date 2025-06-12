using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace eatery_manager_server.Data.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [ForeignKey(nameof(Table))]
        public int TableId { get; set; }

        public Tables? Tables { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; } = string.Empty;

    }
}
