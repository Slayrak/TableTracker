using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Franchises.Commands.DeleteFranchise
{
    public class DeleteFranchiseCommand : IRequest<CommandResponse<FranchiseDTO>>
    {
        public DeleteFranchiseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
