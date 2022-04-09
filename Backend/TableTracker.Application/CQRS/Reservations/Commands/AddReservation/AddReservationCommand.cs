using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Reservations.Commands.AddReservation
{
    public class AddReservationCommand : IRequest<CommandResponse<ReservationDTO>>
    {
        public AddReservationCommand(ReservationDTO reservation)
        {
            Reservation = reservation;
        }

        public ReservationDTO Reservation { get; set; }
    }
}
