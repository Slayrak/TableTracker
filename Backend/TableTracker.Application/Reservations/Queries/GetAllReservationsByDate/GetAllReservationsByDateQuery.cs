using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Reservations.Queries.GetAllReservationsByDate
{
    public class GetAllReservationsByDateQuery : IRequest<ReservationDTO[]>
    {
        public GetAllReservationsByDateQuery(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; set; }
    }
}
