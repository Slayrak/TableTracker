using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Waiters.Queries.GetAllWaiters
{
    public class GetAllWaitersQuery : IRequest<WaiterDTO[]>
    {
    }
}
