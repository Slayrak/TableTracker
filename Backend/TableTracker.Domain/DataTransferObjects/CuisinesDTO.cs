using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.DataTransferObjects
{
    public class CuisinesDTO
    {
        public long Id { get; set; }

        public Cuisine Cuisine { get; set; }

        public ICollection<RestaurantDTO> Restaurants { get; set; }
    }
}
