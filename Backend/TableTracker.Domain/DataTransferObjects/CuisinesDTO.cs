using System.Collections.Generic;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.DataTransferObjects
{
    public class CuisinesDTO
    {
        public long Id { get; set; }

        public CuisineName Cuisine { get; set; }

        public ICollection<RestaurantDTO> Restaurants { get; set; }
    }
}
