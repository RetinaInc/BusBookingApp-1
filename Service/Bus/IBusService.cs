using System;
using System.Collections.Generic;
using Service.BusDto;

namespace Service.Bus
{
    public interface IBusService : IDisposable
    {
        List<ResultDto> GetSchedules();
        List<LocationDto> GetLocations();
        List<ResultDto> SearchSchedules(SearchDto query);
        SeatSelectionDto GetSchedule(int scheduleId);
        void BuyTicket(string seats, int scheduleId, string customer);
        OrderDto Order(string seats, int scheduleId, string customer);
    }
}
