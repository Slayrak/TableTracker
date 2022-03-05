﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Waiters.Queries.FindWaiterById
{
    public class FindWaiterByIdQuery : IRequest<WaiterDTO>
    {
        public FindWaiterByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
