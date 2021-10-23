using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public class Shop
    {
        public List<Item> Storage { get; set; }
        public List<Order> Orders { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public int OrdersCount { get; set; }

        public void LaunchTheStore()
        {
            Storage = new List<Item>();
            Orders = new List<Order>();
            Buyers = new List<Buyer>();
            Suppliers = new List<Supplier>();
            OrdersCount = 0;

            Console.WriteLine("Welcome to the best online shop! \n");

            for (int i = 1; i <= 3; i++)
            {
                Suppliers.Add(new Supplier(i));
            }

            for (int i = 1; i <= 50; i++)
            {
                Buyers.Add(new Buyer(i));
            }
        }

        public bool IsItemAvaliable(Shop shop, Item item, int quantity)
        {
            Item targetItem = shop.Storage.Find(x => x.Name == item.Name);

            if (targetItem.Quantity >= quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListAvaliableItems()
        {
            Storage.GroupBy(x => x.Name);
            foreach (var item in Storage)
            {
                Console.WriteLine($"{item.Name}, quantity: {item.Quantity}");
            }
            Console.WriteLine();
        }
    }
}
