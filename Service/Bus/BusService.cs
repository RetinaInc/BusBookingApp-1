using System;
using System.Collections.Generic;
using System.Linq;
using Service.BusDto;
using Domain.Bus;
using Service.Repository;

namespace Service.Bus
{
    public class BusService : IBusService
    {
        //initialize UnitOfWork
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        //get all the locations
        public List<LocationDto> GetLocations()
        {
            var locations = _unitOfWork.LocationRepository.Get().OrderBy(l => l.Name).ToList();
            return locations.Select(location => new LocationDto {LocationId = location.LocationId, Name = location.Name}).ToList();
        }
        //get all the schedules
        public List<ResultDto> GetSchedules()
        {
            var schedules = _unitOfWork.ScheduleRepository.Get();
            var result = ToResultDto(schedules);
            return result;
        }
        //search for schedules based on given parameters
        public List<ResultDto> SearchSchedules(SearchDto searchBus)
        {
            var schedules = _unitOfWork.ScheduleRepository.Get(
                filter:
                s => s.JourneyFromId == searchBus.JourneyFromId &&
                s.JourneyToId == searchBus.JourneyToId,
                includeProperties: "Company, JourneyFrom, JourneyTo, BusType");

            // filter for date and time
            schedules = schedules.Where(s => s.DepartureTime.Date == searchBus.Departure.Date);
            var result = ToResultDto(schedules);
            return result;
        }
        //get a specific schedule and return it in a SeatSelection object
        public SeatSelectionDto GetSchedule(int scheduleId)
        {
            var schedule = _unitOfWork.ScheduleRepository.GetById(scheduleId);

            //get all the seats in the schedule
            var seats = schedule.BusType.SeatFormat.Seats.
                        Select(seat => new SeatDto
                                {
                                    SeatClass = seat.SeatClass,
                                    SeatNumber = seat.SeatNumber,
                                    Available = true
                                }).ToList();

            //get the booked seats
            //in a real scenario, we'd get the booked seats from the bus company api
            var bookedSeats =
                _unitOfWork.TicketRepository.Get(filter: t => t.ScheduleId == scheduleId)
                    .ToList();

            //if no seats are sold then return all the seats as available seats
            if (bookedSeats.Count <= 0)
                return new SeatSelectionDto
                {
                    ScheduleId = scheduleId,
                    LocationInfo = schedule.JourneyFrom.Name + " to " + schedule.JourneyTo.Name,
                    Departure = schedule.DepartureTime,
                    BusInfo = schedule.Company.Name + " - " + schedule.BusType.Name,
                    Seats = seats
                };

            //if one or more seats are sold then mark them as sold and return the rest
            foreach (var seat in from bookedSeat in bookedSeats
                from seat in seats
                where seat.SeatNumber == bookedSeat.SeatNumber
                select seat)
                seat.Available = false;

            //return the results
            return new SeatSelectionDto
            {
                ScheduleId = scheduleId,
                LocationInfo = schedule.JourneyFrom.Name + " to " + schedule.JourneyTo.Name,
                Departure = schedule.DepartureTime,
                BusInfo = schedule.Company.Name + " - " + schedule.BusType.Name,
                Seats = seats
            };
        }

        // create a pending order for confirmation
        public OrderDto Order(string seats, int scheduleId, string customer)
        {
            //get schedule info
            var schedule = _unitOfWork.ScheduleRepository.GetById(scheduleId);
            
            //create seats
            var strSeats = seats.Split(',');
            var seatList = (from seat in strSeats
                let seatInfo = _unitOfWork.SeatRepository.Get(
                filter: s => s.SeatFormatId == schedule.BusType.SeatFormatId && s.SeatNumber == seat).FirstOrDefault()
                where seatInfo != null
                select new SeatDto
                {
                    SeatNumber = seat,
                    SeatClass = seatInfo.SeatClass
                }).ToList();

            //return the result
            return new OrderDto
            {
                ScheduleId = scheduleId,
                BusInfo = schedule.Company.Name + " - " + schedule.BusType.Name,
                LocationDetail = schedule.JourneyFrom.Name + " to " + schedule.JourneyTo.Name,
                Departure = schedule.DepartureTime,
                Seats = seatList,
                CustomerName = customer
            };
        }

        public void BuyTicket(string seats, int scheduleId, string customer)
        {
            //create the order
            var order = new Order
            {
                Customer = customer,
                ScheduleId = scheduleId
            };

            _unitOfWork.OrderRepository.Create(order);
            _unitOfWork.Save();

            //create tickets
            var schedule = _unitOfWork.ScheduleRepository.GetById(scheduleId);
            var orderedSeats = seats.Split(',');
            foreach (var seatNumber in orderedSeats)
            {
                //check if the seat has already been sold
                var soldSeat = _unitOfWork.TicketRepository.Get(filter: t => t.ScheduleId == scheduleId &&
                                                                             t.SeatNumber == seatNumber);
                if (!soldSeat.Any())
                {
                    //get seat class
                    var seatClass = _unitOfWork.SeatRepository.Get(
                        filter: s => s.SeatFormatId == schedule.BusType.SeatFormatId &&
                                     s.SeatNumber == seatNumber).FirstOrDefault().SeatClass;

                    //create the ticket
                    _unitOfWork.TicketRepository.Create(new Ticket
                    {
                        OrderId = order.OrderId,
                        ScheduleId = scheduleId,
                        SeatNumber = seatNumber,
                        SeatClass = seatClass
                    });
                }
            }
            _unitOfWork.Save();
        }

        // this function converts given list of schedules to ResultDto objects
        private List<ResultDto> ToResultDto(IEnumerable<Schedule> schedules)
        {
            return (from sched in schedules
                    let soldSeats = _unitOfWork.TicketRepository.Get(filter: t => t.ScheduleId == sched.ScheduleId).Count()
                    select new ResultDto
                    {
                        ScheduleId = sched.ScheduleId,
                        Bus = sched.Company.Name + " - " + sched.BusType.Name,
                        AvailableSeats = sched.BusType.SeatFormat.Seats.Count() - soldSeats,
                        Departure = sched.DepartureTime,
                        Description = sched.Description,
                        JourneyFrom = sched.JourneyFrom.Name,
                        JourneyTo = sched.JourneyTo.Name
                    }).ToList();
        }

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
