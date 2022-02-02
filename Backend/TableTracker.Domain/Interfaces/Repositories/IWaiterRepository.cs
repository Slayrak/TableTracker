using System.Collections.Generic;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface IWaiterRepository : IRepository<Waiter, long>
    {
        Task<ICollection<Waiter>> GetAllWaiterByRestaurant(Restaurant restaurant);
    }
}
