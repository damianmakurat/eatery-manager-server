using eatery_manager_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eatery_manager_server.Data.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Tables> Tables { get; set; }

        // USUŃ tę metodę - ona nadpisuje konfigurację z DI
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Data Source=Data/database.db");
        // }
    }
}