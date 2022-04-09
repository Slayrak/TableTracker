using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class VisitorFavouriteRepository : Repository<VisitorFavourite, long>, IVisitorFavouriteRepository
    {
        public VisitorFavouriteRepository(TableDbContext context)
            : base(context)
        {
        }
    }
}
