using System.Collections.Generic;
using Domain.Common;

namespace Domain.Bus
{
    public class TicketOrder : Order
    {
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
