using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Tables.Commands.AddTable
{
    public class AddTableCommand : IRequest<CommandResponse<TableDTO>>
    {
        public AddTableCommand(TableDTO table)
        {
            Table = table;
        }

        public TableDTO Table { get; set; }
    }
}
