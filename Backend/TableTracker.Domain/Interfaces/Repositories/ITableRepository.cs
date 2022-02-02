﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;
using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface ITableRepository : IRepository<Table, long>
    {
        Task<ICollection<Table>> GetAllTablesWithFiltering(
            Restaurant restaurant,
            Waiter waiter = null,
            int? numberOfSeats = null,
            double? TableSize = null,
            int? floor = null,
            DateTime? reserveDate = null,
            TableState? state = null);
    }
}
