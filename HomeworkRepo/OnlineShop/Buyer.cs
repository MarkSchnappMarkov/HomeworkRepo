using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OnlineShop
{
    public class Buyer : Shop
    {
        public int Id { get; set; }
        public double Cash { get; set; }
        public List<Item> ShoppingList { get; set; }
        public Random random { get; set; }
        private static object _locker = new object();

        public Buyer(int id)
        {
            random = new Random();
            Id = id;
            Cash = random.Next(200, 1000);
            ShoppingList = new List<Item>();
        }

        public void CreateAndSendOrder(Shop shop)
        {
            lock (_locker)
            {
                double wantedItemsCost = 0;
                int wantedQuantity = 0;
                List<Item> wantedItems = shop.Storage.OrderBy(x => random.Next()).Take(random.Next(1, 10)).ToList();

                foreach (var wanteditem in wantedItems)
                {
                    wantedQuantity = random.Next(1, 5);
                    wantedItemsCost += wanteditem.Price * wantedQuantity;

                    if (HaveEnoughCash(wantedItemsCost))
                    {
                        if (IsItemAvaliable(shop, wanteditem, wantedQuantity))
                        {
                            Item item = new Item(wanteditem.Name, wanteditem.Price, wantedQuantity);
                            ShoppingList.Add(item);
                            shop.Storage.Find(x => x.Name == wanteditem.Name).Quantity -= wantedQuantity;
                        }
                        else
                            continue;
                    }
                    else
                        continue;
                }
                Order order = new Order(ShoppingList);
                shop.Orders.Add(order);
                shop.OrdersCount++;
            }
        }

        public bool HaveEnoughCash(double bill)
        {
            if (bill <= Cash)
                return true;
            else
                return false;
        }
    }
}
