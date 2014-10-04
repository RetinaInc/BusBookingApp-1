using System.Collections.ObjectModel;
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

        public CartController(IBusService busService)
        {
            _busService = busService;
        }
        
        [HttpPost]
        public CartDto AddTicket(SelectedSeatsDto seats)
        {
            // check if this is the first time the car is initiated
            if (UserCart.UserId == null && UserCart.Orders == null)
            {
                UserCart.UserId = User.Identity.GetUserId();
                UserCart.Orders = new Collection<OrderDto>();
            }
            

            UserCart = _busService.AddToCart(UserCart, seats);
            return UserCart;
        }
    }
}
