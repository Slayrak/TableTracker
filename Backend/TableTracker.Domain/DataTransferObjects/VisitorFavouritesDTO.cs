using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTracker.Domain.DataTransferObjects
{
    public class VisitorFavouritesDTO
    {
        public long Id { get; set; }

        public VisitorDTO Visitor { get; set; }

        public RestaurantDTO Restaurant { get; set; }
    }
}
