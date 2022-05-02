using System;

using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsByDateAndTime
{
    public class GetAllReservationsByDateAndTimeQuery : IRequest<ReservationDTO[]>
    {
        public GetAllReservationsByDateAndTimeQuery(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; set; }
    }
}
