using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.VisitorFavourites.Commands.UpdateVisitorFavourite
{
    public class UpdateVisitorFavouriteCommand : IRequest<CommandResponse<VisitorFavouriteDTO>>
    {
        public UpdateVisitorFavouriteCommand(VisitorFavouriteDTO visitorFavourite)
        {
            VisitorFavourite = visitorFavourite;
        }

        public VisitorFavouriteDTO VisitorFavourite { get; set; }
    }
}
