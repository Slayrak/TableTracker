using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.Waiters.Commands.DeleteWaiter
{
    public class DeleteWaiterCommandHandler : IRequestHandler<DeleteWaiterCommand, CommandResponse<WaiterDTO>>
    {

        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteWaiterCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<WaiterDTO>> Handle(DeleteWaiterCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IWaiterRepository>();
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
                await _unitOfWork.Save();

                return new CommandResponse<WaiterDTO>(_mapper.Map<WaiterDTO>(entity));
            }

            return new CommandResponse<WaiterDTO>(
                _mapper.Map<WaiterDTO>(entity),
                Domain.Enums.CommandResult.NotFound,
                "Could not find given waiter.");
        }
    }
}
