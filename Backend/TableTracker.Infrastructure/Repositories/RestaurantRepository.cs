using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class RestaurantRepository : Repository<Restaurant, long>, IRestaurantRepository
    {
        public RestaurantRepository(TableDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Restaurant>> GetAllRestaurantsWithFiltering(
            float? rating = null,
            IEnumerable<Cuisine> cuisines = null,
            string price = null,
            RestaurantType? type = null,
            Discount? discount = null,
            Franchise franchise = null)
        {
            return await _context
                .Set<Restaurant>()
                .Include(x => x.Tables)
                .Include(x => x.Layout)
                .Include(x => x.Franchise)
                .Where(x => !rating.HasValue || x.Rating == rating)
                .Where(x => cuisines == null || x.Cuisines.All(x => cuisines.Any(y => y.CuisineEnum == x.CuisineEnum)))
                .Where(x => price == null || x.PriceRange == price)
                .Where(x => !type.HasValue || x.Type == type)
                .Where(x => !discount.HasValue || x.Discount == discount)
                .Where(x => franchise == null || x.Franchise == franchise)
                .ToListAsync();
        }
    }
}
