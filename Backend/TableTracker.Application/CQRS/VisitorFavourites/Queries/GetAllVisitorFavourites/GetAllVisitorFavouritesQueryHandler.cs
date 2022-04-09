using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Interfaces.Repositories;

namespace TableTracker.Application.CQRS.VisitorFavourites.Queries.GetAllVisitorFavourites
{
    public class GetAllVisitorFavouritesQueryHandler : IRequestHandler<GetAllVisitorFavouritesQuery, VisitorFavouriteDTO[]>
    {
        private readonly IUnitOfWork<long> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllVisitorFavouritesQueryHandler(
            IUnitOfWork<long> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VisitorFavouriteDTO[]> Handle(GetAllVisitorFavouritesQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                   .GetRepository<IVisitorFavouriteRepository>()
                   .GetAll();

            return result
                .Select(x => _mapper.Map<VisitorFavouriteDTO>(x))
                .ToArray();
        }
    }
}
