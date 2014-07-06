using System.Collections.Generic;

namespace Domain.Bus
{
    public class Location
    {
        public virtual int LocationId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Schedule> FromSchedules { get; set; }
        public virtual ICollection<Schedule> ToSchedules { get; set; }
    }
}
