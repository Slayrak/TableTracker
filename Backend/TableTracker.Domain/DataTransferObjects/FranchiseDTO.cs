using System.Collections.Generic;

namespace TableTracker.Domain.DataTransferObjects
{
    public class FranchiseDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<RestaurantDTO> Restaurants { get; set; }
    }
}
