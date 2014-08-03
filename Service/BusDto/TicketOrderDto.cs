using System.Collections.Generic;
using Service.CommonDto;

namespace Service.BusDto
{
    public class TicketOrderDto : OrderDto
    {
        public int ScheduleId { get; set; }
        public string LocationInfo { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
