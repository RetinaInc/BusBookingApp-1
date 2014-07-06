using System;

namespace Domain.Bus
{
    public class Schedule
    {
        public virtual int ScheduleId { get; set; }
        public virtual string Description { get; set; }
        //[Required]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy  H:mm}")]
        public virtual DateTime DepartureTime { get; set; }
        public virtual int JourneyFromId { get; set; }
        public virtual Location JourneyFrom { get; set; }
        public virtual int JourneyToId { get; set; }        
        public virtual Location JourneyTo { get; set; }
        public virtual int BusTypeId { get; set; }
        public virtual BusType BusType { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
