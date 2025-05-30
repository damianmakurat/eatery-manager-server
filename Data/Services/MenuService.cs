using eatery_manager_server.Data.Models;
using eatery_manager_server.Data.Db;

namespace eatery_manager_server.Data.Services
{
    public class MenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {
            _context = context;
        }

        public void AddMenuItem(Menu item)
        {
            _context.Menu.Add(item);
            _context.SaveChanges();
        }

        public List<Menu> GetMenuItems()
        {
            return _context.Menu.ToList();
        }
    }
}
