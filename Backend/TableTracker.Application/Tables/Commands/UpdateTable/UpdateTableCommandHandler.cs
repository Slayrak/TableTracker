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

namespace TableTracker.Application.Tables.Commands.UpdateTable
{
    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, CommandResponse<TableDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTableCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<TableDTO>> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ITableRepository>();
            var entity = _mapper.Map<Table>(request.Table);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<TableDTO>(request.Table);
            }

            return new CommandResponse<TableDTO>(
                request.Table,
                Domain.Enums.CommandResult.NotFound,
                "Could not find the given table.");
        }

    }
}
