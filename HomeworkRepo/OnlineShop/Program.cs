using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
            shop.MakeTheShopReadyToOpen(shop); 

            //fan out
            List<Task> taskList = new List<Task>();

            for (int i = 0; i <= 49; i++)
            {
                taskList.Add(Task.Run(() =>
                {
                    shop.Buyers.ElementAt(i).CreateAndSendOrder(shop);
                }));
            }

            for (int i = 1; i <= 3; i++)
            {
                taskList.Add(Task.Run(() =>
                {
                    shop.Suppliers.ElementAt(i).LoadItemsToStorage(shop);
                }));
            }
            //fan in
            var closeTask = Task.WhenAll(taskList);
            var final = closeTask.ContinueWith(prev => shop.BuyReport(shop));
            final.Wait();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

    }
}
