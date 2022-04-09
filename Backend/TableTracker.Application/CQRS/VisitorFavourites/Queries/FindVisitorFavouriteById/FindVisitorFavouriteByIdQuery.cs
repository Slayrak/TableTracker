using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.VisitorFavourites.Queries.FindVisitorFavouriteById
{
    public class FindVisitorFavouriteByIdQuery : IRequest<VisitorFavouriteDTO>
    {
        public FindVisitorFavouriteByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
