namespace Domain.Bus
{
    public class Ticket
    {
        public virtual int TicketId { get; set; }
        public virtual string SeatNumber { get; set; }
        public virtual string SeatClass { get; set; }
        public virtual int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
