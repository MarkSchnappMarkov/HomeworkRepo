using System;
using System.Collections.Generic;

namespace OnlineShop
{
    public class Buyer
    {
        public double Cash { get; set; }
        public List<Item> ShoppingList { get; set; }

        public Buyer()
        {
            ShoppingList = new List<Item>();
        }
    }
}
