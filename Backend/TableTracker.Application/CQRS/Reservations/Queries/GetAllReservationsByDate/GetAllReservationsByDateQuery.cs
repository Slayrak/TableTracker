using System;

using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsByDate
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
