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

namespace TableTracker.Application.Reservations.Queries.GetAllReservations
{
    public class GetAllRevervationsQueryHandler : IRequestHandler<GetAllReservationsQuery, ReservationDTO[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRevervationsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReservationDTO[]> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IReservationRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<ReservationDTO>(x))
                .ToArray();
        }
    }
}
