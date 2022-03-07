using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Layout.Commands.UpdateLayout
{
    public class UpdateLayoutCommand : IRequest<CommandResponse<LayoutDTO>>
    {
        public UpdateLayoutCommand(LayoutDTO layoutDTO)
        {
            LayoutDTO = layoutDTO;
        }

        public LayoutDTO LayoutDTO { get; set; }
    }
}
