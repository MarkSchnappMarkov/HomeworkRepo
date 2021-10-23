using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop
{
    class Program
    {
        public int OrdersCount { get; set; }

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            Shop shop = new Shop();

            Task first = new Task(shop.LaunchTheStore);
            first.Start();

            //fan out
            first.Wait();

            List<Task> taskList = new List<Task>();

            for (int i = 0; i < 3; i++)
            {
                taskList.Add(Task.Run(() =>
                {
                    shop.Suppliers.ElementAt(i).LoadItemsToStorage(shop);
                }));
            }

            shop.ListAvaliableItems();

            for (int i = 0; i < 50; i++)
            {
                shop.Buyers.ElementAt(i).CreateAndSendOrder(shop);
            }

            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
