using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Layout.Queries.FindLayoutByRestaurant
{
    public class FindLayoutByRestaurantQuery : IRequest<LayoutDTO>
    {
        public FindLayoutByRestaurantQuery(RestaurantDTO restaurantDTO)
        {
            RestaurantDTO = restaurantDTO;
        }

        public RestaurantDTO RestaurantDTO { get; set; }
    }
}
