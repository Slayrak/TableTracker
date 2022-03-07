using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Layout.Commands.AddLayout
{
    public class AddLayoutCommand : IRequest<CommandResponse<LayoutDTO>>
    {
        public AddLayoutCommand(LayoutDTO layoutDTO)
        {
            LayoutDTO = layoutDTO;
        }

        public LayoutDTO LayoutDTO { get; set; }
    }
}
