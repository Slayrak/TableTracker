using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Managers.Queries.FindManagerByRestaurant
{
    public class FindManagerByRestaurantQuery : IRequest<ManagerDTO>
    {
        public FindManagerByRestaurantQuery(RestaurantDTO restaurantDTO)
        {
            RestaurantDTO = restaurantDTO;
        }

        public RestaurantDTO RestaurantDTO { get; set; }
    }
}
