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

namespace TableTracker.Application.Reservations.Queries.GetAllReservationsByDate
{
    public class GetAllReservationsByDateQueryHandler : IRequestHandler<GetAllReservationsByDateQuery, ReservationDTO[]>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReservationsByDateQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReservationDTO[]> Handle(GetAllReservationsByDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IReservationRepository>()
                .GetAllReservationsByDate(
                    date: request.Date);

            return result
                .Select(x => _mapper.Map<ReservationDTO>(x))
                .ToArray();
        }
    }
}
