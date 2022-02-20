using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class CuisineRepository : Repository<Cuisines, long>, ICuisineRepository
    {
        public CuisineRepository(TableDbContext context)
             : base(context)
        {
        }

        public async Task<Cuisines> GetCuisineByName(CuisineName cuisine)
        {
            return await _context
                .Set<Cuisines>()
                .FirstOrDefaultAsync(x => x.Cuisine == cuisine);
        }
    }
}
