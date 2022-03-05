using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Waiters.Commands.UpdateWaiter
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
