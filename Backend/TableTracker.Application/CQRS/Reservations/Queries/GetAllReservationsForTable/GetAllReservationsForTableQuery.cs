using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsForTable
{
    public class GetAllReservationsForTableQuery : IRequest<ReservationDTO[]>
    {
        public GetAllReservationsForTableQuery(ReservationFilterModel model)
        {
            Model = model;
        }

        public ReservationFilterModel Model { get; set; }
    }
}
