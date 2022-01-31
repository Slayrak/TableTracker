using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTracker.Domain.Entities
{
    public class Reservation : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Visitor> Visitors { get; set; }
        public long TableId { get; set; }
        public Table Table { get; set; }
    }
}
