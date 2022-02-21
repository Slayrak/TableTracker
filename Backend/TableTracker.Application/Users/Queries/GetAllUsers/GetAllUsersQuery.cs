using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<UserDTO[]>
    {
    }
}
