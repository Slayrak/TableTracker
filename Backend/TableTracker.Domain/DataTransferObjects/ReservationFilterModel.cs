using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTracker.Domain.DataTransferObjects
{
    public class ReservationFilterModel
    {
        public TableDTO Table { get; set; }

        public DateTime? Date { get; set; }    
    }
}
