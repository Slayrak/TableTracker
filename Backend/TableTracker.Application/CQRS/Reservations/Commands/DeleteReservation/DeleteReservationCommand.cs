using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<CommandResponse<ReservationDTO>>
    {
        public DeleteReservationCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
