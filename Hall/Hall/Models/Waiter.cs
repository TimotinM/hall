using Hall.Services;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;

namespace Hall.Models
{
     class Waiter 
     {
          public readonly int Id;
          private readonly Semaphore _tablesSemaphore;       
          
          public Waiter(int id, Semaphore tablesSemaphore)
          {
               Id = id;
               _tablesSemaphore = tablesSemaphore;
          }

          public void Work()
          {
               Thread t = new(new ThreadStart(() =>
               {
                    while(true)
                    {
                         _tablesSemaphore.WaitOne();
                         foreach (var table in DiningHall.Instance.Tables.ToArray())
                         {
                              if (table.State == TableStateEnum.WaitingToOrder)
                              {
                                   var order = table.GenerateOrder();
                                   var data = new OrderToSend
                                   {
                                        order_id = order.id,
                                        table_id = order.table_id,
                                        waiter_id = Id,
                                        items = order.items,
                                        priority = order.priority,
                                        max_wait = order.max_wait,
                                        pick_up_time = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                                   };
                                   Console.WriteLine($"Order {order.id} was picked up by the waiter {Id}");
                                   var _order = new OrderServices();
                                  _order.SendOrder("http://localhost:5000/order", data);
                              }
                         }
                    }
               }));

               t.Start();
          }

          public void ServeOrder(Distribution order)
          {
               var table = DiningHall.Instance.Tables.Single(table => table.Id == order.table_id);
               table.ReciveOrder(order);
          }
     }
}
