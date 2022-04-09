using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Waiters.Queries.GetAllWaitersByRestaurant
{
    public class GetAllWaitersByRestaurantQuery : IRequest<WaiterDTO[]>
    {
        public GetAllWaitersByRestaurantQuery(RestaurantDTO restaurant)
        {
            Restaurant = restaurant;
        }

        public RestaurantDTO Restaurant { get; set; }
    }
}
