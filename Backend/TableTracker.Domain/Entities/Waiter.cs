using System;
using System.Collections.Generic;
using System.Text;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Waiter : User
    {
        public int NumberOfServingTables { get; set; }
        public WaiterState WaiterState { get; set; }
        public long RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        public ICollection<Table> Tables { get; set; }
        public Visitor Visitor { get; set; }
    }
}
