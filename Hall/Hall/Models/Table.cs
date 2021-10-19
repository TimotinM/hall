using Hall.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hall.Models
{
     class Table
     {
          private TableStateEnum _state;
          public readonly int Id;
          private DiningHall _diningHall;
          public TableStateEnum State
          {
               get
               {
                    return _state;
               }
               set
               {
                    if (value == TableStateEnum.Free)
                    {
                         Task.Delay(new Random().Next(100, 500)).ContinueWith((task) =>
                         {
                              _state = TableStateEnum.WaitingToOrder;
                              _diningHall.HandleNewOrder();
                         });
                    }
                    _state = value;
               }
          }

          public Table(int id, DiningHall diningHall)
          {
               Id = id;
               State = TableStateEnum.Free;
               _diningHall = diningHall;
          }

          public Order GenerateOrder()
          {
               var random = new Random();
               var numberOfFoods = random.Next(1, 10);
               int[] foods = new int[numberOfFoods];
               for (var i = 0; i < numberOfFoods; i++)
               {
                    var foodId = random.Next(10);
                    while (foods.Contains(foodId))
                    {
                         foodId = random.Next(1, 10);
                    }
                    foods[i] = foodId;
               }
               State = TableStateEnum.WaitingToBeServed;
               var orderId = Guid.NewGuid().GetHashCode();
               return new Order(orderId, foods, random.Next(1, 5), Id);
          }

          public void ReciveOrder(Distribution order)
          {
               if(order.table_id == this.Id)
               {
                    State = TableStateEnum.Free;
                    var stars = GetOrderStar(order);
                    DiningHall.Instance.Marks.Add(stars);
               }
          }

          private int GetOrderStar(Distribution order)
          {
               var orderTotalTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() - order.pick_up_time;
               Console.WriteLine(orderTotalTime + "    " + order.max_wait);
               if (orderTotalTime  < order.max_wait) return 5;
               if (orderTotalTime * 1.1 < order.max_wait) return 4;
               if (orderTotalTime * 1.2 < order.max_wait) return 3;
               if (orderTotalTime * 1.3 < order.max_wait) return 2;
               if (orderTotalTime * 1.4 < order.max_wait) return 1;
               return 1;
          }
     }
}
