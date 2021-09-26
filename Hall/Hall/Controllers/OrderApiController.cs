using Hall.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hall.Controllers
{
     [Route("[controller]")]
     [ApiController]
     [Produces("application/json")]
     public class OrderApiController : Controller
     {
          private readonly IOrder _order;

          public OrderApiController(IOrder order)
          {
               _order = order;
          }

          [HttpPost("Order")]
          public IActionResult Order()
          {
               var response = _order.CreateOrder(1, 1, 1);
               return Json(response);
          }
     }
}
