using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.Waiters.Commands.AddWaiter
{
    public class AddWaiterCommandHandler : IRequestHandler<AddWaiterCommand, CommandResponse<WaiterDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public AddWaiterCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<WaiterDTO>> Handle(AddWaiterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Waiter>(request.Waiter);

            if(entity.Id != 0)
            {
                return new CommandResponse<WaiterDTO>(
                    request.Waiter,
                    CommandResult.Failure,
                    "The waiter is already in a database.");
            }

            await _unitOfWork.GetRepository<IWaiterRepository>().Insert(entity);
            await _unitOfWork.Save();

            return new CommandResponse<WaiterDTO>(request.Waiter);
        }

    }
}
