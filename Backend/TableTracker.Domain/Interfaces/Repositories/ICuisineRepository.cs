using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface ICuisineRepository : IRepository<Cuisines, long>
    {
        Task<Cuisines> GetCuisineByName(CuisineName cuisineName);
    }
}
