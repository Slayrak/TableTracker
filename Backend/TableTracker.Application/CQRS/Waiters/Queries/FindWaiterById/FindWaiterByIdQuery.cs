using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Waiters.Queries.FindWaiterById
{
    public class FindWaiterByIdQuery : IRequest<WaiterDTO>
    {
        public FindWaiterByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
