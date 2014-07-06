using System.Collections.Generic;
using System.Web.Http;
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

        [HttpPost]
        public IEnumerable<ResultDto> Search(SearchDto query)
        {
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
