using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Tables.Queries.FindTableById
{
    public class FindTableByIdQuery : IRequest<TableDTO>
    {
        public FindTableByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

    }
}
