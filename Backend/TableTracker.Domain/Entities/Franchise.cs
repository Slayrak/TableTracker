using System.Collections.Generic;

namespace TableTracker.Domain.Entities
{
    public class Franchise : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
