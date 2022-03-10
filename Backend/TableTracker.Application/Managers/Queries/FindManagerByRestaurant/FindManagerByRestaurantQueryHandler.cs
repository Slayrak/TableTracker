﻿using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.Managers.Queries.FindManagerByRestaurant
{
    public class FindManagerByRestaurantQueryHandler : IRequestHandler<FindManagerByRestaurantQuery, ManagerDTO>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public FindManagerByRestaurantQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ManagerDTO> Handle(FindManagerByRestaurantQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IManagerRepository>()
                .FindManagerByRestaurant(_mapper.Map<Restaurant>(request.RestaurantDTO));

            return _mapper.Map<ManagerDTO>(result);
        }
    }
}