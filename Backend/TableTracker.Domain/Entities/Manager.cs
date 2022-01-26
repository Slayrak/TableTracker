using System;
using System.Collections.Generic;
using System.Text;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.Entities
{
    public class Manager : User
    {
        public ManagerState ManagerState { get; set; }

        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
