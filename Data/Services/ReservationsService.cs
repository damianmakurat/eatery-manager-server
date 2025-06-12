using eatery_manager_server.Data.Models;
using Microsoft.EntityFrameworkCore;
using eatery_manager_server.Data.Db;

namespace eatery_manager_server.Data.Services
{
    public class ReservationsService
    {
        private readonly AppDbContext _context;

        public ReservationsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservations>> GetReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Tables) // jeśli chcesz mieć dostęp do szczegółów stolika
                .ToListAsync();
        }

        public async Task<List<Tables>> GetAvailableTablesAsync(DateOnly date, TimeOnly startTime, TimeOnly endTime)
        {
            var reservedTableIds = await _context.Reservations
                .Where(r => r.Date == date &&
                            !(r.EndTime <= startTime || r.StartTime >= endTime))
                .Select(r => r.TableId)
                .ToListAsync();

            return await _context.Tables
                .Where(t => !reservedTableIds.Contains(t.TableId))
                .ToListAsync();
        }

        public async Task AddReservationAsync(Reservations reservation)
        {
            bool isConflict = await _context.Reservations.AnyAsync(r =>
                r.TableId == reservation.TableId &&
                r.Date == reservation.Date &&
                !(r.EndTime <= reservation.StartTime || r.StartTime >= reservation.EndTime));

            if (isConflict)
            {
                throw new InvalidOperationException("Stolik jest już zarezerwowany w wybranym czasie.");
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
