using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<CommandResponse<ReservationDTO>>
    {
        public UpdateReservationCommand(ReservationDTO reservation)
        {
            Reservation = reservation;
        }

        public ReservationDTO Reservation { get; set; }
    }
}
