using Hall.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Hall.Services
{
     public class OrderServices
     {         
          //public Order CreateOrder(int id, int tableId, int waiterId)
          //{
          //     var rand = new Random();
          //     Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
          //     int[] foods = new int[rand.Next(1, 6)];
          //     for (int i = 0; i < foods.Length; i++)
          //     {
          //          foods[i] = rand.Next(1, 10);
          //     }
          //     var order = new Order()
          //     {
          //          order_id = id,
          //          table_id = tableId,
          //          waiter_id = waiterId,
          //          items = foods,
          //          priority = rand.Next(1, 5),
          //          max_wait = GetMaxWait(foods),
          //          pick_up_time = unixTimestamp

          //     };
          //     return order;
          //}

          public void SendOrder(string url, OrderToSend data)
          {           
               using (var client = new HttpClient())
               {
                    var postTask = client.PostAsJsonAsync<OrderToSend>(url, data);
                    postTask.Wait();

                    var result = postTask.Result;
               }
          }

          private float GetMaxWait(int [] items)
          {
              StreamReader r = new StreamReader("Common\\Items.json");           
              string json = r.ReadToEnd();
              List<Item> allItems = JsonConvert.DeserializeObject<List<Item>>(json);
               
               int max = 0;
               foreach (var item in items)
               {
                    var preparationTime = allItems.Where(i => i.id == item).Select(i => i.preparation_time).FirstOrDefault();
                    if (preparationTime > max)
                         max = preparationTime;
               }
               return max * 1.3f;
          }
     }
}
