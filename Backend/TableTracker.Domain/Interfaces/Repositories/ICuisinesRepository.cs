using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface ICuisinesRepository : IRepository<Cuisines, long>
    {
        Task<Cuisines> FindCuisineByName(Cuisine cuisine);
    }
}
