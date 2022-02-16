﻿using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.Queries.Restaurants.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, RestaurantDTO[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRestaurantsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RestaurantDTO[]> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IRestaurantRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<RestaurantDTO>(x))
                .ToArray();
        }
    }
}