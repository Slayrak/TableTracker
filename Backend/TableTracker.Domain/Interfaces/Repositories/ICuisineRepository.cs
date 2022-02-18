using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface ICuisineRepository : IRepository<Cuisines, long>
    {
        Task<Cuisines> GetCuisineByName(Cuisine cuisine);
    }
}
