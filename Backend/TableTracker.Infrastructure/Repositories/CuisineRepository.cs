using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class CuisineRepository : Repository<Cuisine, long>, ICuisineRepository
    {
        public CuisineRepository(TableDbContext context)
             : base(context)
        {
        }

        public async Task<Cuisine> GetCuisineByName(CuisineName cuisine)
        {
            return await _context
                .Set<Cuisine>()
                .FirstOrDefaultAsync(x => x.CuisineEnum == cuisine);
        }
    }
}
