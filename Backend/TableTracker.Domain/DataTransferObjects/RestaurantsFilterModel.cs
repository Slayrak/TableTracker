using System.Collections.Generic;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.DataTransferObjects
{
    public class RestaurantsFilterModel
    {
        public float? Rating { get; set; }

        public IEnumerable<CuisinesDTO> Cuisines { get; set; }

        public string Price { get; set; }

        public RestaurantType? Type { get; set; }

        public Discount? Discount { get; set; }

        public FranchiseDTO Franchise { get; set; }
    }
}
