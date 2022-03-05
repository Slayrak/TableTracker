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
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.Waiters.Commands.UpdateWaiter
{
    public class UpdateWaiterCommandHandler : IRequestHandler<UpdateWaiterCommand, CommandResponse<WaiterDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWaiterCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<WaiterDTO>> Handle(UpdateWaiterCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IWaiterRepository>();
            var entity = _mapper.Map<Waiter>(request.Waiter);

            if(await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<WaiterDTO>(request.Waiter);
            }

            return new CommandResponse<WaiterDTO>(
                request.Waiter,
                Domain.Enums.CommandResult.NotFound,
                "Could not find the given waiter."
                );

        }
    }
}
