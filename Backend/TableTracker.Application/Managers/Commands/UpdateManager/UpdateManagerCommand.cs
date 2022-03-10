using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Managers.Commands.UpdateManager
{
    public class UpdateManagerCommand : IRequest<CommandResponse<ManagerDTO>>
    {
        public UpdateManagerCommand(ManagerDTO managerDTO)
        {
            ManagerDTO = managerDTO;
        }

        public ManagerDTO ManagerDTO { get; set; }
    }
}
