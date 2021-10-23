using System;
using System.Collections.Generic;

namespace OnlineShop
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public List<Item> OrderedItems { get; set; }
        
        public Order(int ordNum, List<Item> itemsToBuy)
        {
            OrderNumber = ordNum;
            OrderedItems = new List<Item>();
        }
    }
}
