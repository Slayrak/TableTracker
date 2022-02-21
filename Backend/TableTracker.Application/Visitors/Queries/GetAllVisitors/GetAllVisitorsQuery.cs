using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Visitors.Queries.GetAllVisitors
{
    public class GetAllVisitorsQuery : IRequest<VisitorDTO[]>
    {
    }
}
