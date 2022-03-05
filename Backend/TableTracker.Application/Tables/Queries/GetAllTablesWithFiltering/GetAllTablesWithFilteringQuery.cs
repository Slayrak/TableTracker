﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Application.Tables.Queries.GetAllTablesWithFiltering
{
    public class GetAllTablesWithFilteringQuery : IRequest<TableDTO[]>
    {
        public GetAllTablesWithFilteringQuery(TableFilterModel tableFilterModel)
        {
            FilterModel = tableFilterModel;
        }

        public TableFilterModel FilterModel { get; set; }
    }
}