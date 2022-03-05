using AutoMapper;

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

namespace TableTracker.Application.Waiters.Queries.GetAllWaiterByRestaurant
{
    public class GetAllWaiterByRestaurantQueryHandler : IRequestHandler<GetAllWaiterByRestaurantQuery, WaiterDTO[]>
    {

        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWaiterByRestaurantQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WaiterDTO[]> Handle(GetAllWaiterByRestaurantQuery response, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IWaiterRepository>()
                .GetAllWaiterByRestaurant(restaurant: _mapper.Map<Restaurant>(response.Restaurant));

            return result
                .Select(x => _mapper.Map<WaiterDTO>(x))
                .ToArray();
        }
    }
}
