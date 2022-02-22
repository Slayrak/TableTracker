using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class CuisinesRepository : Repository<Cuisine, long>, ICuisinesRepository
    {
        public CuisinesRepository(TableDbContext context)
            : base(context)
        {
        }

        public async Task<Cuisine> FindCuisineByName(CuisineName cuisine)
        {
            return await _context
                .Set<Cuisine>()
                .FirstOrDefaultAsync(x => x.CuisineEnum == cuisine);
        }
    }
}
