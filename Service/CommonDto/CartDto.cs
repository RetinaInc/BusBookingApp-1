using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Service.BusDto;

namespace Service.CommonDto
{
    public class CartDto
    {
        public string UserId { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}
