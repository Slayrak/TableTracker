using System;
using System.Collections.Generic;
using System.Text;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Table
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public TableState State { get; set; }
        public DateTime ReserveDate { get; set; }
        public int NumberOfSeats { get; set; }
        public int Floor { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public double TableSize { get; set; }
        public long ServingWaiterId { get; set; }


        public long WaiterId { get; set; }
        public Waiter Waiter { get; set; }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
