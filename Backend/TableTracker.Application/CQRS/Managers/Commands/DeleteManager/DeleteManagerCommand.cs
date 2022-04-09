using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Managers.Commands.DeleteManager
{
    public class DeleteManagerCommand : IRequest<CommandResponse<ManagerDTO>>
    {
        public DeleteManagerCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
