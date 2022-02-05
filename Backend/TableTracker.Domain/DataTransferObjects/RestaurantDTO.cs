using System.Collections.Generic;

using TableTracker.Domain.Enums;

//TODO change Cuisines Type
namespace TableTracker.Domain.DataTransferObjects
{
    public class RestaurantDTO
    {
        public long Id { get; set; }

        public double CoordX { get; set; }

        public double CoordY { get; set; }

        public float Rating { get; set; }

        public string PriceRange { get; set; }

        public int NumberOfTables { get; set; }

        public RestaurantType Type { get; set; }

        public Discount Discount { get; set; }

        public ICollection<TableDTO> Tables { get; set; }

        public ICollection<WaiterDTO> Waiters { get; set; }

        public ICollection<string> Cuisines { get; set; }

        public FranchiseDTO Franchise { get; set; }

        public LayoutDTO Layout { get; set; }
    }
}
