namespace Domain.Bus
{
    public class BusType
    {
        public virtual int BusTypeId { get; set; }
        public virtual string Name { get; set; }
        public virtual int SeatFormatId { get; set; }
        public virtual SeatFormat SeatFormat { get; set; }
    }
}
