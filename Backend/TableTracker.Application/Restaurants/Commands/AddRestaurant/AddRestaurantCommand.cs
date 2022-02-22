using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Restaurants.Commands.AddRestaurant
{
    public class AddRestaurantCommand : IRequest<CommandResponse<RestaurantDTO>>
    {
        public AddRestaurantCommand(RestaurantDTO restaurant)
        {
            Restaurant = restaurant;
        }

        public RestaurantDTO Restaurant { get; set; }
    }
}
