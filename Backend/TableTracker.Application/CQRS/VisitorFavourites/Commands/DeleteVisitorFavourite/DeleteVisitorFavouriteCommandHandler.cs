using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.VisitorFavourites.Commands.DeleteVisitorFavourite
{
    public class DeleteVisitorFavouriteCommandHandler : IRequestHandler<DeleteVisitorFavouriteCommand, CommandResponse<VisitorFavouriteDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteVisitorFavouriteCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<VisitorFavouriteDTO>> Handle(DeleteVisitorFavouriteCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IVisitorFavouriteRepository>();
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
                await _unitOfWork.Save();

                return new CommandResponse<VisitorFavouriteDTO>(_mapper.Map<VisitorFavouriteDTO>(entity));
            }

            return new CommandResponse<VisitorFavouriteDTO>(
                _mapper.Map<VisitorFavouriteDTO>(entity),
                CommandResult.NotFound,
                "Could not find the given visitor favourite.");
        }
    }
}
