using System.Collections.Generic;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Cuisines : IEntity<long>
    {
        public long Id { get; set; }

        public CuisineName Cuisine { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
