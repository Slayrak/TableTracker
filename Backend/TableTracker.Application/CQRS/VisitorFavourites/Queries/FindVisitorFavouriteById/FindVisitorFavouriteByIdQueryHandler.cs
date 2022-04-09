using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.VisitorFavourites.Queries.FindVisitorFavouriteById
{
    public class FindVisitorFavouriteByIdQueryHandler : IRequestHandler<FindVisitorFavouriteByIdQuery, VisitorFavouriteDTO>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public FindVisitorFavouriteByIdQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VisitorFavouriteDTO> Handle(FindVisitorFavouriteByIdQuery request, CancellationToken cancellationToken)
        {
            var visitorFavourite = await _unitOfWork
                .GetRepository<IVisitorFavouriteRepository>()
                .FindById(request.Id);

            return _mapper.Map<VisitorFavouriteDTO>(visitorFavourite);
        }
    }
}
