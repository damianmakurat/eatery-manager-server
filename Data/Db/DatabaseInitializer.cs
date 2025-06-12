using eatery_manager_server.Data.Db;
using eatery_manager_server.Data.Models;

namespace eatery_manager_server.Data.Db
{
    public static class DatabaseInitializer
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Menu.Any())
            {
                var menuItems = new List<Menu>
            {
                new Menu { Name = "Pizza Margherita", Price = 25.99m, Ingredients = "Pomidor, mozzarella, bazylia", Order = 1, Category = "Dania główne" },
                new Menu { Name = "Lasagne", Price = 35.50m, Ingredients = "Makaron, mięso mielone, sos pomidorowy, beszamel", Order = 2, Category = "Dania główne" },
                new Menu { Name = "Spaghetti Carbonara", Price = 29.99m, Ingredients = "Makaron, jajka, guanciale, pecorino, pieprz", Order = 3, Category = "Dania główne" },
                new Menu { Name = "Risotto z owocami morza", Price = 42.00m, Ingredients = "Ryż arborio, krewetki, małże, sos pomidorowy", Order = 4, Category = "Dania główne" },
                new Menu { Name = "Tiramisu", Price = 18.00m, Ingredients = "Mascarpone, kawa, kakao, biszkopty", Order = 5, Category = "Desery" },
                new Menu { Name = "Focaccia", Price = 12.50m, Ingredients = "Ciasto drożdżowe, oliwa, rozmaryn", Order = 6, Category = "Przystawki" },
                new Menu { Name = "Gnocchi z pesto", Price = 28.00m, Ingredients = "Kluski ziemniaczane, pesto bazyliowe, parmezan", Order = 7, Category = "Dania główne" },
                new Menu { Name = "Bruschetta", Price = 16.00m, Ingredients = "Bagietka, pomidory, oliwa, czosnek, bazylia", Order = 8, Category = "Przystawki" },
                new Menu { Name = "Tagliatelle z truflami", Price = 55.00m, Ingredients = "Makaron, trufle, masło, parmezan", Order = 9, Category = "Dania główne" },
                new Menu { Name = "Cannoli", Price = 22.00m, Ingredients = "Chrupiące rurki, ricotta, czekolada, pistacje", Order = 10, Category = "Desery" }
            };

                context.Menu.AddRange(menuItems);
                await context.SaveChangesAsync();
            }

            if (!context.Tables.Any())
            {
                var tables = new List<Tables>
            {
                new Tables { TableId = 1, LocationX = "1A", LocationY = "2B", Capacity = 4 },
                new Tables { TableId = 2, LocationX = "1B", LocationY = "2C", Capacity = 2 },
                new Tables { TableId = 3, LocationX = "3A", LocationY = "4B", Capacity = 6 },
                new Tables { TableId = 4, LocationX = "3B", LocationY = "4C", Capacity = 8 },
                new Tables { TableId = 5, LocationX = "5A", LocationY = "6B", Capacity = 4 }
            };
                context.Tables.AddRange(tables);
                await context.SaveChangesAsync();
            }

            if (!context.Reservations.Any())
            {
                var reservations = new List<Reservations>
            {
                new Reservations { TableId = 1, Date = new DateOnly(2025, 6, 15), StartTime = new TimeOnly(18, 00), EndTime = new TimeOnly(20, 00), Name = "Jakub", Surname = "Kowalski" },
                new Reservations { TableId = 2, Date = new DateOnly(2025, 6, 16), StartTime = new TimeOnly(19, 30), EndTime = new TimeOnly(21, 00), Name = "Anna", Surname = "Nowak" },
                new Reservations { TableId = 3, Date = new DateOnly(2025, 6, 17), StartTime = new TimeOnly(17, 45), EndTime = new TimeOnly(19, 45), Name = "Piotr", Surname = "Wiśniewski" }
            };
                context.Reservations.AddRange(reservations);
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }
}