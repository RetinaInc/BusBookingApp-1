﻿using System;
using System.Collections.Generic;

namespace Service.BusDto
{
    public class OrderDto
    {
        public int ScheduleId { get; set; }
        public string BusInfo { get; set; }
        public string LocationDetail { get; set; }
        public DateTime Departure { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
        public string CustomerName { get; set; }
    }
}
