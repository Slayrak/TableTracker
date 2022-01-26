using System;
using System.Collections.Generic;
using System.Text;

namespace TableTracker.Domain.Entities
{
    public class Layout
    {
        public long Id { get; set; }
        public byte LayoutData { get; set; }

        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
