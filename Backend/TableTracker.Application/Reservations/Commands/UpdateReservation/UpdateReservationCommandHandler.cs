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

namespace TableTracker.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, CommandResponse<ReservationDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<ReservationDTO>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IReservationRepository>();
            var entity = _mapper.Map<Reservation>(request.Reservation);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<ReservationDTO>(request.Reservation);
            }

            return new CommandResponse<ReservationDTO>(
                request.Reservation,
                Domain.Enums.CommandResult.NotFound,
                "Could not find the given reservation.");
        }
    }
}
