using System.Collections.Generic;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Cuisine : IEntity<long>
    {
        public long Id { get; set; }
        public CuisineName CuisineEnum { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
