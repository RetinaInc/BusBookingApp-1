using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Service.Bus;
using Service.BusDto;

namespace RestService.Controllers
{
    public class BusController : ApiController
    {
        // the bus service interface
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        
        [HttpGet]
        public IEnumerable<ResultDto> Schedules()
        {
            return _busService.GetSchedules();
        }

        //get list of locations
        [HttpGet]
        public IEnumerable<LocationDto> Locations()
        {
            return _busService.GetLocations();
        }

        [HttpGet]
        [Route("service/Bus/Schedules/{fromId}/{toId}/{departure}")]
        public IEnumerable<ResultDto> Search(int fromId, int toId, string departure)
        {
            var query = new SearchDto
            {
                JourneyFromId = fromId,
                JourneyToId = toId,
                Departure = DateTime.ParseExact(departure, "dd-MM-yyyy", null)
            };
            return _busService.SearchSchedules(query);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _busService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
