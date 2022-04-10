using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.Waiters.Queries.GetAllWaitersByRestaurant
{
    public class GetAllWaitersByRestaurantQueryHandler : IRequestHandler<GetAllWaitersByRestaurantQuery, WaiterDTO[]>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWaitersByRestaurantQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WaiterDTO[]> Handle(GetAllWaitersByRestaurantQuery response, CancellationToken cancellationToken)
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
