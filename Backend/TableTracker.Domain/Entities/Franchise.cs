using System;
using System.Collections.Generic;
using System.Text;

namespace TableTracker.Domain.Entities
{
    public class Franchise : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
