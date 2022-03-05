using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Waiters.Queries.GetAllWaiterByRestaurant
{
    public class GetAllWaiterByRestaurantQuery : IRequest<WaiterDTO[]>
    {
        public GetAllWaiterByRestaurantQuery(RestaurantDTO restaurant)
        {
            Restaurant = restaurant;
        }

        public RestaurantDTO Restaurant { get; set; }
    }
}
