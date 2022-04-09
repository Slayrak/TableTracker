using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;

namespace TableTracker.Application.CQRS.Cuisines.Commands.AddCuisine
{
    public class AddCuisineCommand : IRequest<CommandResponse<CuisineDTO>>
    {
        public AddCuisineCommand(CuisineDTO cuisine)
        {
            Cuisine = cuisine;
        }

        public CuisineDTO Cuisine { get; set; }
    }
}
