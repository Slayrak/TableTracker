using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Waiters.Commands.DeleteWaiter
{
    public class DeleteWaiterCommand : IRequest<CommandResponse<WaiterDTO>>
    {
        public DeleteWaiterCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
