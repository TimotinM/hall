using Hall.Models;
using Hall.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.Json;

namespace Hall.Controllers
{
     public class OrderApiController : Controller
     {

          [HttpPost("distribution")]
          public IActionResult Order([FromBody] Distribution distribution)
          {
               Console.WriteLine("received order");
               var waiter = DiningHall.Instance.Waiters.Single(waiter => waiter.Id == distribution.waiter_id);
               waiter.ServeOrder(distribution);
               return Ok();
          }
     }
}
