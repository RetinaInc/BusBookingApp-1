using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
