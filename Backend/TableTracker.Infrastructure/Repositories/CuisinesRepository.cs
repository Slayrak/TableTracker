using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class CuisinesRepository : Repository<Cuisines, long>, ICuisinesRepository
    {
        public CuisinesRepository(TableDbContext context)
            : base(context)
        {
        }

        public async Task<Cuisines> FindCuisineByName(Cuisine cuisine)
        {
            return await _context
                .Set<Cuisines>()
                .FirstOrDefaultAsync(x => x.Cuisine == cuisine);
        }
    }
}
