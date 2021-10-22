using System;
using System.Collections.Generic;

namespace OnlineShop
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public List<Item> OrderedItems { get; set; }

        public Order()
        {
            OrderedItems = new List<Item>();
        }
    }
}
