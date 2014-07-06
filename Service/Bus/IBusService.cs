using System;
using System.Collections.Generic;
using Service.BusDto;

namespace Service.Bus
{
    public interface IBusService : IDisposable
    {
        List<ResultDto> GetSchedules();
        List<LocationDto> GetLocations();
        List<ResultDto> SearchBus(SearchDto searchBus);
        SeatSelectionDto GetSeats(int scheduleId);
        void BuyTicket(string seats, int scheduleId, string customer);
        OrderDto Order(string seats, int scheduleId, string customer);
    }
}
