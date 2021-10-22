using System;
using System.Collections.Generic;

namespace OnlineShop
{
    public class Supplier
    {
        public int Name { get; set; }
        List<Item> ItemList { get; set; }

        public Supplier()
        {
            ItemList = new List<Item>();
        }
    }
}
