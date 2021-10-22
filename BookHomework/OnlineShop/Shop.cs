using System;
using System.Collections.Generic;

namespace OnlineShop
{
    public class Shop
    {
        public List<Item> Storage { get; set; }
        public List<Order> Orders { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Supplier> Suppliers { get; set; }

        public Shop()
        {
            Storage = new List<Item>();
            Orders = new List<Order>();
            Buyers = new List<Buyer>();
            Suppliers = new List<Supplier>();
        }

        public void LaunchTheStore()
        {
            Console.WriteLine("Welcome to the best online shop!");
        }
    }
}
