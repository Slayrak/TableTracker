using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.VisitorFavourites.Commands.DeleteVisitorFavourite
{
    public class DeleteVisitorFavouriteCommand : IRequest<CommandResponse<VisitorFavouriteDTO>>
    {
        public DeleteVisitorFavouriteCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
