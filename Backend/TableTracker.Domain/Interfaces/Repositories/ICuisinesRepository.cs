using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface ICuisinesRepository : IRepository<Cuisine, long>
    {
        Task<Cuisine> FindCuisineByName(CuisineName cuisine);
    }
}
