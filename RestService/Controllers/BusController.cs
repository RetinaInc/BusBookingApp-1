using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Service.Bus;
using Service.BusDto;

namespace RestService.Controllers
{
    [RoutePrefix("service/bus")]
    public class BusController : ApiController
    {
        // the bus service interface
        private readonly IBusService _busService;

        public BusController()
        {
        }

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        
        //get all locations
        //Route: service/bus/locations
        [Authorize]
        [HttpGet]
        public IEnumerable<LocationDto> Locations()
        {
            return _busService.GetLocations();
        }
        //get all schedules
        //Route: service/bus/schedules
        [Authorize]
        [HttpGet]
        public IEnumerable<ResultDto> Schedules()
        {
            return _busService.GetSchedules();
        }
        //search for schedules
        //Route: service/bus/schedules/{from location id}/{to location id}/{departure time}
        [HttpGet]
        [Route("Schedules/{fromId}/{toId}/{departure}")]
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
        //get a specific schedule
        //Route: service/bus/schedule/{id}
        [HttpGet]
        public SeatSelectionDto Schedule(int id)
        {
            return _busService.GetSchedule(id);
        }

        [Authorize]
        [HttpGet]
        public string GetUserId()
        {
            return User.Identity.GetUserId();
            //return User.Identity.
            /*ClaimsIdentity ci = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var usr = ci.Claims.Where(c => c.Type == "sub").FirstOrDefault();
            return usr.Value;*/


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
