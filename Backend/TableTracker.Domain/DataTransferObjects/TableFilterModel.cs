using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.DataTransferObjects
{
    public class TableFilterModel
    {
        public RestaurantDTO Restaurant { get; set; }
        
        public WaiterDTO Waiter { get; set; }
         
        public int? NumberOfSeats { get; set; }
         
        public double? TableSize { get; set; }
         
        public int? Floor { get; set; }
         
        public DateTime? ReserveDate { get; set; }
         
        public TableState State { get; set; }
    }
}
