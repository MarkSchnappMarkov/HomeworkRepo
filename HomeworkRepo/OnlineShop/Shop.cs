using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class Shop
    {
        public List<Item> Storage { get; set; }
        public List<Order> Orders { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public int OrdersCount { get; set; }
        private static object _locker = new object();

        public void LaunchTheStore()
        {
            lock (_locker)
            {
                Storage = new List<Item>();
                Orders = new List<Order>();
                Buyers = new List<Buyer>();
                Suppliers = new List<Supplier>();
                OrdersCount = 0;

                Console.WriteLine("Welcome to the best online shop! \n");

                for (int i = 1; i <= 3; i++)
                {
                    Supplier supplier = new Supplier();
                    Suppliers.Add(supplier);
                }

                for (int i = 1; i <= 50; i++)
                {
                    Buyer buyer = new Buyer(i);
                    Buyers.Add(buyer);
                }
            }
        }

        public bool IsItemAvaliable(Shop shop, Item item, int quantity)
        {
            if (shop.Storage.Find(x => x.Name == item.Name).Quantity >= quantity)
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
            lock (_locker)
            {
                Storage.GroupBy(x => x.Name);
                foreach (var item in Storage)
                {
                    Console.WriteLine($"{item.Name}, price {item.Price} , quantity: {item.Quantity}");
                }
                Console.WriteLine();
            }
        }

        public void BuyReport(Shop shop)
        {
            lock (_locker)
            {
                foreach (var buyer in shop.Buyers)
                {
                    if (buyer.ShoppingList.Capacity != 0)
                    {
                        Console.WriteLine($"Buyer {buyer.Id} with {buyer.Cash} cash is buying: ");
                        foreach (var item in buyer.ShoppingList)
                        {
                            Console.WriteLine($"{item.Name}, quantity: {item.Quantity}, BILL: {item.Quantity * item.Price}");
                        }
                        Console.WriteLine();
                    }
                }
            } 
        }
    }
}
