using System;

namespace Hall.Models
{
     public class Distribution
     {
          public int order_id { get; set; }
          public int table_id { get; set; }
          public int waiter_id { get; set; }
          public int[] items { get; set; }
          public int priority { get; set; }
          public float max_wait { get; set; }
          public Int32 pick_up_time { get; set; }
          public override string ToString()
          {
               return $"Order-{order_id} was taken by the waiter-{waiter_id} from the table-{table_id} at {UnixTimeStampToDateTime(pick_up_time)}.";
          }

          private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
          {
               DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
               dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
               return dateTime;
          }
     }
}
