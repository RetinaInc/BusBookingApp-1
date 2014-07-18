using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class Seat
    {
        [Key]
        public virtual int SeatId { get; set; }
        [Required]
        public virtual string UniqueId { get; set; }
        [Required]
        [MaxLength(10)]
        public virtual string SeatClass { get; set; }
        [Required]
        [MaxLength(10)]
        public virtual string SeatNumber { get; set; }
        [Required]
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
