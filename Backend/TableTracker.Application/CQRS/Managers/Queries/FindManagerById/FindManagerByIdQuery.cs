using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.CQRS.Managers.Queries.FindManagerById
{
    public class FindManagerByIdQuery : IRequest<ManagerDTO>
    {
        public FindManagerByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
