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

namespace TableTracker.Application.Tables.Queries.FindTableById
{
    public class FindTableByIdQueryHandler : IRequestHandler<FindTableByIdQuery, TableDTO>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public FindTableByIdQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TableDTO> Handle(FindTableByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
               .GetRepository<ITableRepository>()
               .FindById(request.Id);

            return _mapper.Map<TableDTO>(result);
        }

    }
}
