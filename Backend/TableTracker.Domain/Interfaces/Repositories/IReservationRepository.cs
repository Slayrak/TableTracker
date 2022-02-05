using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface IReservationRepository : IRepository<Reservation, long>
    {
        Task<ICollection<Reservation>> GetAllReservationsByDate(DateTime date);

        Task<ICollection<Reservation>> GetAllReservationsForTable(Table table, DateTime? date = null);
    }
}
