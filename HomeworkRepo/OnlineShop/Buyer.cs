using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public class Buyer : Shop
    {
        public Shop Shop { get; set; }
        public int Id { get; set; }
        public double Cash { get; set; }
        public List<Item> ShoppingList { get; set; }
        public Random random { get; set; }

        public Buyer(int id)
        {
            random = new Random();
            Id = id;
            Cash = random.Next(10000, 100000);
            ShoppingList = new List<Item>();
        }

        public void CreateAndSendOrder(Shop shop)
        {
            Shop = shop;
            Random rand = new Random();
            double wantedItemsCost = 0;
            List<Item> planningToBuy = new List<Item>();

            for (int i = 0; i < rand.Next(1,10); i++)
            {
                Item wantedItem = shop.Storage.ElementAt(i);
                int wantedQuantity = rand.Next(1, 10);           
                
                if (IsItemAvaliable(shop, wantedItem, wantedQuantity))
                {
                    wantedItemsCost += wantedItem.Price;
                    wantedItem.Quantity = wantedQuantity;
                    planningToBuy.Add(wantedItem);
                }
                else
                {
                    planningToBuy.Remove(wantedItem); //removing the wanted item because its unable to be bought
                }
            }

            if (wantedItemsCost <= Cash) // if the buyer has enough money to bu ywanted items
            {
                ShoppingList = planningToBuy;
            }
            else
            {
                Console.WriteLine("not enough money to buy what i want");
            }

            Order order = new Order(OrdersCount++, ShoppingList);
            OrdersCount++;
            order.OrderedItems = ShoppingList;
            shop.Orders.Add(order);

            if (ShoppingList.Capacity == 0)
            {
                Console.WriteLine($"Buyer number {Id} have empty shopping list \n");
            }
            else
            {
                Console.WriteLine($"Buyer number {Id} with cash: {Cash} is buying :");
                foreach (var item in order.OrderedItems)
                {
                    Console.WriteLine($"{item.Name}, price: {item.Price} leva, quantity: {item.Quantity}, Total: {item.Price * item.Quantity} leva");
                }
                Console.WriteLine();
            }    
        }
    }
}
