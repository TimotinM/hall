using Hall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hall.Services
{
     public interface IOrder
     {
         //Distribution CreateOrder(int id, int tableId, int waiterId);
          void SendOrder(string url, OrderToSend data);
     }
}
