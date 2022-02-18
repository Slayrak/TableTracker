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

namespace TableTracker.Application.Franchises.Queries.GetAllFranchises
{
    public class GetAllFranchisesQueryHandler : IRequestHandler<GetAllFranchisesQuery, FranchiseDTO[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllFranchisesQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FranchiseDTO[]> Handle(GetAllFranchisesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IFranchiseRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<FranchiseDTO>(x))
                .ToArray();
        }
    }
}
