namespace eatery_manager_server.Data.Models;
using System.ComponentModel.DataAnnotations;

public class Menu
{
    [Key]
    public int Id { get; set; } // Klucz główny, powinien być automatycznie generowany

    [Required]
    public string Name { get; set; } = string.Empty; // Initialize with a default value

    [Required]
    public decimal Price { get; set; }
}
