using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<CommandResponse<RestaurantDTO>>
    {
        public DeleteRestaurantCommand(long restaurantId)
        {
            RestaurantId = restaurantId;
        }

        public long RestaurantId { get; set; }
    }
}
