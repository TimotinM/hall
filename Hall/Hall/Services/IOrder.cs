using Hall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hall.Services
{
     public interface IOrder
     {
          Order CreateOrder(int id, int tableId, int waiterId);
     }
}
