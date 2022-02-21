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

namespace TableTracker.Application.Cuisines.Queries.GetAllCuisines
{
    public class GetAllCuisinesQueryHandler : IRequestHandler<GetAllCuisinesQuery, CuisinesDTO[]>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCuisinesQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //TODO: Handler
        public async Task<CuisinesDTO[]> Handle(GetAllCuisinesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
               .GetRepository<ICuisineRepository>()
               .GetAll();

            return result
                .Select(x => _mapper.Map<CuisinesDTO>(x))
                .ToArray();
        }

    }
}
