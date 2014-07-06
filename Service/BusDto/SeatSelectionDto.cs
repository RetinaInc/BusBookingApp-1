using System;
using System.Collections.Generic;

namespace Service.BusDto
{
    public class SeatSelectionDto
    {
        public int ScheduleId { get; set; }
        public string LocationInfo { get; set; }
        public DateTime Departure { get; set; }
        public string BusInfo { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
