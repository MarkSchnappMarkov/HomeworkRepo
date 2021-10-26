using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OnlineShop
{
    public class Supplier : Shop
    {
        public int Id { get; set; }
        private static object _locker = new object();

        public Supplier(int id)
        {
            Id = id;
        }

        public void LoadItemsToStorage(Shop shop)
        {
            lock (_locker)
            {
                Random rand = new Random();

                if (shop.Storage.Any(x => x.Name == "Smartphone")) //if exists, then increase quantity
                    shop.Storage.Find(x => x.Name == "Smartphone").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Smartphone", 1500, rand.Next(1000, 2000))); //if not add the item

                if (shop.Storage.Any(x => x.Name == "Wallet"))
                    shop.Storage.Find(x => x.Name == "Wallet").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Wallet", 89, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Chair"))
                    shop.Storage.Find(x => x.Name == "Chair").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Chair", 45, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Jacket"))
                    shop.Storage.Find(x => x.Name == "Jacket").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Jacket", 129, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "TV"))
                    shop.Storage.Find(x => x.Name == "TV").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("TV", 800, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Skateboard"))
                    shop.Storage.Find(x => x.Name == "Skateboard").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Skateboard", 110, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Electric scooter"))
                    shop.Storage.Find(x => x.Name == "Electric scooter").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Electric scooter", 850, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Vacum cleaner"))
                    shop.Storage.Find(x => x.Name == "Vacum cleaner").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Vacum cleaner", 230, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Lighter"))
                    shop.Storage.Find(x => x.Name == "Lighter").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Lighter", 2, rand.Next(1000, 2000)));

                if (shop.Storage.Any(x => x.Name == "Light bulb"))
                    shop.Storage.Find(x => x.Name == "Light bulb").Quantity += rand.Next(1000, 2000);
                else
                    shop.Storage.Add(new Item("Light bulb", 5, rand.Next(1000, 2000)));
            }
        }
    }
}
