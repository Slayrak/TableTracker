using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class ReservationRepository : Repository<Reservation, long>, IReservationRepository
    {
        public ReservationRepository(TableDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Reservation>> GetAllReservationsByDateAndTime(long restaurantId, DateTime date)
        {
            return await _context
                .Set<Reservation>()
                .Include(x => x.Visitors)
                .Include(x => x.Table)
                .Where(x => x.Table.RestaurantId == restaurantId && x.Date == date)
                .ToListAsync();
        }

        public async Task<ICollection<Reservation>> GetAllReservationsByDate(long restaurantId, DateTime date)
        {
            return await _context
                .Set<Reservation>()
                .Include(x => x.Visitors)
                .Include(x => x.Table)
                .Where(x => x.Table.RestaurantId == restaurantId && x.Date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<ICollection<Reservation>> GetAllReservationsForTable(Table table, DateTime? date = null)
        {
            return await _context.Set<Reservation>()
                .Include(x => x.Visitors)
                .Include(x => x.Table)
                .Where(x => x.TableId == table.Id)
                .Where(x => !date.HasValue || x.Date == date)
                .ToListAsync();
        }

        public async Task<ICollection<Reservation>> GetAllReservations(long restaurantId)
        {
            return await _context.Set<Reservation>()
                .Include(x => x.Visitors)
                .Include(x => x.Table)
                .Where(x => x.Table.RestaurantId == restaurantId)
                .ToListAsync();
        }
    }
}
