using System;

namespace Service.BusDto
{
    public class ResultDto
    {
        public int ScheduleId { get; set; }
        public string Description { get; set; }
        public string JourneyFrom { get; set; }
        public string JourneyTo { get; set; }
        public DateTime Departure { get; set; }
        public string Bus { get; set; }
        public int AvailableSeats { get; set; }
    }
}
