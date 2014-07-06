namespace Domain.Bus
{
    public class Seat
    {
        public virtual int SeatId { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SeatClass { get; set; }
        public virtual string SeatNumber { get; set; }
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
