using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Bus
{
    public class TicketOrder : Order
    {
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
