using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Cuisines : IEntity<long>
    {
        public long Id { get; set; }

        public Cuisine Cuisine { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
