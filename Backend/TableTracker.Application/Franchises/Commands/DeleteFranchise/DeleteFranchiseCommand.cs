﻿using MediatR;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Franchises.Commands.DeleteFranchise
{
    public class DeleteFranchiseCommand : IRequest<CommandResponse<FranchiseDTO>>
    {
        public DeleteFranchiseCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
