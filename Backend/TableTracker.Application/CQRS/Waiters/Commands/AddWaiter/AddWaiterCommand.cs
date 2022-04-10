using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Waiters.Commands.AddWaiter
{
    public class AddWaiterCommand : IRequest<CommandResponse<WaiterDTO>>
    {
        public AddWaiterCommand(WaiterDTO waiter)
        {
            Waiter = waiter;
        }

        public WaiterDTO Waiter { get; set; }
    }
}
