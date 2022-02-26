﻿using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Restaurants.Queries.GetAllRestaurantsWithFiltering
{
    public class GetAllRestaurantsWithFilteringQuery : IRequest<RestaurantDTO[]>
    {
        public GetAllRestaurantsWithFilteringQuery(RestaurantsFilterModel filterModel)
        {
            FilterModel = filterModel;
        }

        public RestaurantsFilterModel FilterModel { get; set; }
    }
}
