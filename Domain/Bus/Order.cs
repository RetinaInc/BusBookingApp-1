using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class Order
    {
        [Key]
        public virtual int OrderId { get; set; }
        public virtual string Customer { get; set; }
        public int ScheduleId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
