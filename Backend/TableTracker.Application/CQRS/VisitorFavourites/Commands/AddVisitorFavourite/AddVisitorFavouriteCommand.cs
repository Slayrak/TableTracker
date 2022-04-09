using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.VisitorFavourites.Commands.AddVisitorFavourite
{
    public class AddVisitorFavouriteCommand : IRequest<CommandResponse<VisitorFavouriteDTO>>
    {
        public AddVisitorFavouriteCommand(VisitorFavouriteDTO visitorFavourites)
        {
            VisitorFavourite = visitorFavourites;
        }

        public VisitorFavouriteDTO VisitorFavourite { get; set; }
    }
}
