using System.Collections.Generic;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant, long>
    {
        Task<ICollection<Restaurant>> GetAllRestaurantsWithFilteringByRating(
            float? rating = null,
            IEnumerable<string> cuisines = null,
            string price = null,
            RestaurantType? type = null,
            Discount? discount = null,
            Franchise franchise = null);
    }
}
