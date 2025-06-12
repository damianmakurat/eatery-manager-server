using eatery_manager_server.Data.Db;
using eatery_manager_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eatery_manager_server.Data.Services
{
    public class MenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMenuItemAsync(Menu item)
        {
            _context.Menu.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Menu>> GetMenuItemsAsync()
        {
            return await _context.Menu.ToListAsync();
        }

        public async Task<Menu?> GetMenuItemByIdAsync(int id)
        {
            return await _context.Menu.FindAsync(id);
        }

        public async Task UpdateMenuItemAsync(Menu item)
        {
            _context.Menu.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var item = await _context.Menu.FindAsync(id);
            if (item != null)
            {
                _context.Menu.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            return await _context.Menu
                .Select(m => m.Category)
                .Distinct()
                .Where(c => !string.IsNullOrEmpty(c))
                .ToListAsync();
        }

    }
}
