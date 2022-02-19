using System.Collections.Generic;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant, long>
    {
        Task<ICollection<Restaurant>> GetAllRestaurantsWithFiltering(
            float? rating = null,
            IEnumerable<Cuisines> cuisines = null,
            string price = null,
            RestaurantType? type = null,
            Discount? discount = null,
            Franchise franchise = null);
    }
}
