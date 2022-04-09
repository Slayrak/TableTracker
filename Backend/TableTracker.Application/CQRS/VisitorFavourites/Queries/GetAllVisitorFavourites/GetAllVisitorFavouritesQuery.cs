using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.VisitorFavourites.Queries.GetAllVisitorFavourites
{
    public class GetAllVisitorFavouritesQuery : IRequest<VisitorFavouriteDTO[]>
    {
    }
}
