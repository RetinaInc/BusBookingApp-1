using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class SeatFormat
    {
        [Key]
        public virtual int SeatFormatId { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
