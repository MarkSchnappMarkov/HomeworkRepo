using System;
using System.Collections.Generic;

namespace OnlineShop
{
    public class Order
    {
        public List<Item> OrderedItems { get; set; }
        public double Bill { get; set; }
        
        public Order(List<Item> items)
        {
            OrderedItems = items;

            foreach (var item in items)
            {
                Bill += item.Price * item.Quantity;
            }
        }
    }
}
