using System.Collections.Generic;

namespace Service.BusDto
{
    public class SelectedSeatsDto
    {
        public int ScheduleId { get; set; }
        public string LocationInfo { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
