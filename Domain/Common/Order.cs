using System;

namespace Domain.Common
{
    public class Order
    {
        public Order()
        {
            OrdeDate = DateTime.Now;
        }

        public virtual int OrderId { get; set; }
        public virtual string UserId { get; set; }
        public DateTime OrdeDate { get; set; }
    }
}
