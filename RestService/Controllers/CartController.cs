using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Service.Bus;
using Service.BusDto;
using Service.CommonDto;

namespace RestService.Controllers
{

    [Authorize]
    public class CartController : ApiController
    {
        
        private readonly IBusService _busService;
        public static CartDto UserCart = new CartDto();

        public CartController()
        {
            UserCart.UserId = User.Identity.GetUserId();
        }

        public CartController(IBusService busService)
        {
            _busService = busService;
        }
        
        [HttpPost]
        public CartDto AddTicket(SelectedSeatsDto seats)
        {
            UserCart = _busService.AddToCart(UserCart, seats);
            return UserCart;
        }
    }
}
