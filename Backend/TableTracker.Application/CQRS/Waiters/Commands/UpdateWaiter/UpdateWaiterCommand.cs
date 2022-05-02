using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Waiters.Commands.UpdateWaiter
{
    public class UpdateWaiterCommand : IRequest<CommandResponse<WaiterDTO>>
    {
        public UpdateWaiterCommand(WaiterDTO waiter)
        {
            Waiter = waiter;
        }

        public WaiterDTO Waiter { get; set; }
    }
}
