using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.VisitorFavourites.Commands.AddVisitorFavourite
{
    public class AddVisitorFavouriteCommandHandler : IRequestHandler<AddVisitorFavouriteCommand, CommandResponse<VisitorFavouriteDTO>>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public AddVisitorFavouriteCommandHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<VisitorFavouriteDTO>> Handle(
            AddVisitorFavouriteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<VisitorFavourite>(request.VisitorFavourite);

            if (entity.Id != 0)
            {
                return new CommandResponse<VisitorFavouriteDTO>(
                    request.VisitorFavourite,
                    CommandResult.Failure,
                    "The visitor favourite is already in the database");
            }

            await _unitOfWork
                .GetRepository<IVisitorFavouriteRepository>()
                .Insert(entity);

            await _unitOfWork.Save();

            return new CommandResponse<VisitorFavouriteDTO>(_mapper.Map<VisitorFavouriteDTO>(entity));
        }
    }
}
