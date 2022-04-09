using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
