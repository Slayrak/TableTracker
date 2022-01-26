using System;
using System.Collections.Generic;
using System.Text;

namespace TableTracker.Domain.Entities
{
    public class VisitorHistory
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }

        public Visitor Visitor { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
