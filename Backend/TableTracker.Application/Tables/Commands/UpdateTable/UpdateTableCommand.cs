using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Tables.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest<CommandResponse<TableDTO>>
    {
        public UpdateTableCommand(TableDTO table)
        {
            Table = table;
        }

        public TableDTO Table { get; set; }
    }
}
