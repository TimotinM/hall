using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hall.Models
{
     public class Item
     {
          public int id { get; set; }
          public string name { get; set; }
          public int preparation_time { get; set; }
          public int complexity { get; set; }
          public string cooking_apparatus { get; set; }
     }
}
