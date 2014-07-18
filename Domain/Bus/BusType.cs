using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class BusType
    {
        [Key]
        public virtual int BusTypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }
        [Required]
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
