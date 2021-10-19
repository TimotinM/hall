using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hall.Models
{
     public class OrderToSend
     {
          public int order_id { get; set; }
          public int table_id { get; set; }
          public int waiter_id { get; set; }
          public int[] items { get; set; }
          public int priority { get; set; }
          public float max_wait { get; set; }
          public Int32 pick_up_time { get; set; }
     }
}
