using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusDto
{
    public class SelectedSeatsDto
    {
        public int ScheduleId { get; set; }
        public string LocationInfo { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
