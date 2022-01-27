using System;
using System.Collections.Generic;
using System.Text;

namespace TableTracker.Domain.Entities
{
    public class Visitor : User
    {
        public float GeneralTrustFactor { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
