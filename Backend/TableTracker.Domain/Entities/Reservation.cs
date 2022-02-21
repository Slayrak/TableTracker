using System;
using System.Collections.Generic;

namespace TableTracker.Domain.Entities
{
    public class Reservation : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Visitor> Visitors { get; set; }

        public Table Table { get; set; }
        public long TableId { get; set; }
    }
}
