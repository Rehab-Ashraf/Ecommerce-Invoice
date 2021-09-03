using INVOICE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INVOICE.Controllers
{
    public class CartController : ApiController
    {
        public static List<CartItems> CartItems = new List<CartItems>();

        [HttpPost]
        [Route("api/Cart/setCartItem")]
       public void setCartItem(List<CartItems> items)
        {
            CartItems.AddRange(items);
        }
    
    }
}
