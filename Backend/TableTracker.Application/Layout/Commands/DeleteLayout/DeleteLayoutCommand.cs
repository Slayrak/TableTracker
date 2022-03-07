using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Layout.Commands.DeleteLayout
{
    public class DeleteLayoutCommand : IRequest<CommandResponse<LayoutDTO>>
    {
        public DeleteLayoutCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
