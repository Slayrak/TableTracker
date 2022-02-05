using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class VisitorRepository : Repository<Visitor, long>, IVisitorRepository
    {
        public VisitorRepository(TableDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Visitor>> FilterVisitors(string filter)
        {
            return await _context
                .Set<Visitor>()
                .Include(x => x.Reservations)
                .Where(x => x.FullName.Contains(filter) || x.Email.Contains(filter))
                .ToListAsync();
        }

        public async Task<ICollection<Visitor>> GetAllVisitorsByTrustFactor(float trustFactor)
        {
            return await _context
                .Set<Visitor>()
                .Include(x => x.Reservations)
                .Where(x => x.GeneralTrustFactor == trustFactor)
                .ToListAsync();
        }
    }
}
