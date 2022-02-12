using System.Collections.Generic;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.DataTransferObjects
{
    public class WaiterDTO
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public int NumberOfServingTables { get; set; }

        public WaiterState WaiterState { get; set; }

        public ICollection<TableDTO> Tables { get; set; }

        public RestaurantDTO Restaurant { get; set; }

        public ICollection<ReservationDTO> Reservations { get; set; }
    }
}
