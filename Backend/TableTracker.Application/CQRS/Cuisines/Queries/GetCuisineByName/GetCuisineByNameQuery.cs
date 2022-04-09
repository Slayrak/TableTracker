using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Enums;

namespace TableTracker.Application.CQRS.Cuisines.Queries.GetCuisineByName
{
    public class GetCuisineByNameQuery : IRequest<CuisineDTO>
    {
        public GetCuisineByNameQuery(CuisineName name)
        {
            Name = name;
        }

        public CuisineName Name { get; set; }
    }
}
