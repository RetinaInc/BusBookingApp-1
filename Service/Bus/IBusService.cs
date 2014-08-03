using System;
using System.Collections.Generic;
using Service.BusDto;
using Service.CommonDto;

namespace Service.Bus
{
    public interface IBusService : IDisposable
    {
        // get all schedules
        List<ResultDto> GetSchedules();
        // get all locations
        List<LocationDto> GetLocations();
        // search for schedules
        List<ResultDto> SearchSchedules(SearchDto query);
        // get a specific schedule
        SeatSelectionDto GetSchedule(int scheduleId);
        // order a ticket
        CartDto AddToCart(CartDto cart, SelectedSeatsDto seats);
        //OrderDto Order(string seats, int scheduleId, string customer);
        // buy a ticket/confirm order
        void BuyTicket(CartDto cart);
        
    }
}
