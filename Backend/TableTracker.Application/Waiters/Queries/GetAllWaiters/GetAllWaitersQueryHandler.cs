using AutoMapper;

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

namespace TableTracker.Application.Waiters.Queries.GetAllWaiters
{
    public class GetAllWaitersQueryHandler : IRequestHandler<GetAllWaitersQuery, WaiterDTO[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWaitersQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WaiterDTO[]> Handle(GetAllWaitersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IWaiterRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<WaiterDTO>(x))
                .ToArray();
        }
    }
}
