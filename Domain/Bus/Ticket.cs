using System.ComponentModel.DataAnnotations;
namespace Domain.Bus
{
    public class Ticket
    {
        [Key]
        public virtual int TicketId { get; set; }
        [Required]
        [MaxLength(10)]
        public virtual string SeatNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public virtual string SeatClass { get; set; }
        [Required]
        public virtual int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        [Required]
        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
