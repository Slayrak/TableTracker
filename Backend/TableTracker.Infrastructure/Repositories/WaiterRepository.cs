using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class WaiterRepository : Repository<Waiter, long>, IWaiterRepository
    {
        public WaiterRepository(TableDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Waiter>> FilterWaiters(string filter)
        {
            return await _context
                .Set<Waiter>()
                .Include(x => x.Restaurant)
                .Include(x => x.Reservations)
                .Where(x => x.FullName.Contains(filter) || x.Email.Contains(filter))
                .ToListAsync();
        }

        public async Task<ICollection<Waiter>> GetAllWaiterByRestaurant(Restaurant restaurant)
        {
            return await _context
                .Set<Waiter>()
                .Include(x => x.Restaurant)
                .Include(x => x.Reservations)
                .Where(x => x.RestaurantId == restaurant.Id)
                .ToListAsync();
        }
    }
}
