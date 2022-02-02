using System;
using System.Collections.Generic;
using System.Text;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Restaurant : IEntity<long>
    {
        public long Id { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public float Rating { get; set; }
        public string PriceRange { get; set; }
        public int NumberOfTables { get; set; }
        public RestaurantType Type { get; set; }
        public Discount Discount { get; set; }

        public ICollection<Table> Tables { get; set; }
        public ICollection<Waiter> Waiters { get; set; }
        public ICollection<Cuisines> Cuisines { get; set; }

        public long FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        public long LayoutId { get; set; }
        public Layout Layout { get; set; }
        public long ManagerId { get; set; }
        public Manager Manager { get; set; }

    }
}
