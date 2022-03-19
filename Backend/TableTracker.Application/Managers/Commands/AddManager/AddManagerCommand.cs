using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Managers.Commands.AddManager
{
    public class AddManagerCommand : IRequest<CommandResponse<ManagerDTO>>
    {
        public AddManagerCommand(ManagerDTO managerDTO)
        {
            ManagerDTO = managerDTO;
        }

        public ManagerDTO ManagerDTO { get; set; }
    }
}
