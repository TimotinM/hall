using Hall.Models;
using System;
using System.Linq;

namespace Hall.Models
{
     class Order
     {
          public readonly int id;
          public readonly float max_wait;
          public int[] items { get; set; }
          public int priority { get; set; }
          public int table_id { get; set; }

          public Order(int Id, int[] Items, int Priority, int TableId)
          {
               id = Id;
               items = Items;
               priority = Priority;
               table_id = TableId;
               max_wait = Menu.Instance.MenuItems.Where(item => Items.Contains(item.Id)).Select(item => item.PreparationTime).Max() * 1.3f;
          }
     }
}
