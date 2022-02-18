using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UserDTO[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO[]> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IUserRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<UserDTO>(x))
                .ToArray();
        }

    }
}
