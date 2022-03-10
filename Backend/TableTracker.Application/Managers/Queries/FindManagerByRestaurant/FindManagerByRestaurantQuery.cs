using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Managers.Queries.FindManagerByRestaurant
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
