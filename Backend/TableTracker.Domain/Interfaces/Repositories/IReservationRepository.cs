using System;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface IReservationRepository : IRepository<Reservation, long>
    {
        Task<Reservation> GetAllReservationsByDate(DateTime date);

        Task<Reservation> GetAllReservationsForTable(Table table, DateTime? date = null);
    }
}
