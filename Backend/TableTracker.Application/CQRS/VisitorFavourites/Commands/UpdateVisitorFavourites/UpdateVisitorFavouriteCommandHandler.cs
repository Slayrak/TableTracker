using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.VisitorFavourites.Commands.UpdateVisitorFavourite
{
    public class UpdateVisitorFavouriteCommandHandler : IRequestHandler<UpdateVisitorFavouriteCommand, CommandResponse<VisitorFavouriteDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVisitorFavouriteCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<VisitorFavouriteDTO>> Handle(
            UpdateVisitorFavouriteCommand request,
            CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IVisitorFavouriteRepository>();
            var entity = _mapper.Map<VisitorFavourite>(request.VisitorFavourite);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<VisitorFavouriteDTO>(request.VisitorFavourite);
            }

            return new CommandResponse<VisitorFavouriteDTO>(
                request.VisitorFavourite,
                CommandResult.NotFound,
                "Could not find the given visitor favourite.");
        }
    }
}
