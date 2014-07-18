using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class CartController : ApiController
    {
        [HttpPost]
        [Route("service/Cart/Add/{itemType}/{toId}/{departure}")]
        public void AddItem()
        {
        }

    }
}
