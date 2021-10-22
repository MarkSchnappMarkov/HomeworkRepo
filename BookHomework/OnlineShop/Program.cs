using System;
using System.Collections.Generic;

namespace OnlineShop
{
    class Program
    {
        public int OrdersCount { get; set; }

        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.LaunchTheStore();
        }
    }
}
