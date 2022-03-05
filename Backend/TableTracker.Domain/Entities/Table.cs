using System.Collections.Generic;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Table : IEntity<long>
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public TableState State { get; set; }
        public int NumberOfSeats { get; set; }
        public int Floor { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public double TableSize { get; set; }

        public long? WaiterId { get; set; }
#nullable enable
        public Waiter? Waiter { get; set; }
#nullable disable
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
