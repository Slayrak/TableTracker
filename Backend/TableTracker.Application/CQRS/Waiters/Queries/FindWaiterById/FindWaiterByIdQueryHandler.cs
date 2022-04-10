using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.Waiters.Queries.FindWaiterById
{
    public class FindWaiterByIdQueryHandler : IRequestHandler<FindWaiterByIdQuery, WaiterDTO>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public FindWaiterByIdQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WaiterDTO> Handle(FindWaiterByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IWaiterRepository>()
                .FindById(request.Id);

            return _mapper.Map<WaiterDTO>(result);
        }
    }
}
