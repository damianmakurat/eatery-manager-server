using eatery_manager_server.Data.Models;
using Microsoft.EntityFrameworkCore;
using eatery_manager_server.Data.Db;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eatery_manager_server.Data.Services
{
    public class TablesService
    {
        private readonly AppDbContext _context;

        public TablesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tables>> GetTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Tables?> GetTableByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task AddTableAsync(Tables table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table is not null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
