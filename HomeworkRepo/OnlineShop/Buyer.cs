using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public class Buyer : Shop
    {
        public int Id { get; set; }
        public double Cash { get; set; }
        public List<Item> ShoppingList { get; set; }
        public Random random { get; set; }

        public Buyer(int id)
        {
            random = new Random();
            Id = id;
            Cash = random.Next(2000, 50000);
            ShoppingList = new List<Item>();
        }

        public void CreateAndSendOrder(Shop shop)
        {
            double wantedItemsCost = 0;
            int wantedQuantity = random.Next(1, 5);

            List<Item> wantedItems = shop.Storage.OrderBy(x => random.Next()).Take(random.Next(1, 10)).ToList();

            foreach (var item in wantedItems)
            {
                wantedItemsCost += item.Price * wantedQuantity;

                if (HaveEnoughCash(wantedItemsCost))
                {
                    if (IsItemAvaliable(shop, item, wantedQuantity))
                    {
                        item.Quantity = wantedQuantity;
                        ShoppingList.Add(item);
                        shop.Storage.Find(x => x.Name == item.Name).Quantity -= wantedQuantity;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            Order order = new Order(ShoppingList);
            shop.Orders.Add(order);
            shop.OrdersCount++;
        }

        public bool HaveEnoughCash(double bill)
        {
            if (bill <= Cash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
