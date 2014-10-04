using System.Collections.Generic;

namespace Service.CommonDto
{
    public class CartDto
    {
        public string UserId { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}
