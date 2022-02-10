using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Infrastructure.Repositories
{
    public class VisitorFavouritesRepository : Repository<VisitorFavourites, long>, IVisitorFavouritesRepository
    {
        public VisitorFavouritesRepository(TableDbContext context)
            : base(context)
        {
        }
    }
}
