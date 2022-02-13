﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.Enums;

namespace TableTracker.Domain.DataTransferObjects
{
    public class TableDTO
    {
        public long Id { get; set; }

        public int Number { get; set; }

        public TableState State { get; set; }

        public int NumberOfSeats { get; set; }

        public int Floor { get; set; }

        public double CoordX { get; set; }

        public double CoordY { get; set; }

        public double TableSize { get; set; }

        public WaiterDTO Waiter { get; set; }

        public RestaurantDTO Restaurant { get; set; }

        public ICollection<ReservationDTO> Reservations { get; set; }
    }
}
