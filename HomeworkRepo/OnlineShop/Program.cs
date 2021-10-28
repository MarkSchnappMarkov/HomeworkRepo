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
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Shop shop = new Shop();

            List<Thread> BuyerThreads = new List<Thread>();
            List<Thread> SupplierThreads = new List<Thread>();

            Thread first = new Thread(shop.LaunchTheStore);
            first.Start();
            first.Join();

            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(() => shop.Suppliers.ElementAt(i).LoadItemsToStorage(shop));
                thread.Start();
                SupplierThreads.Add(thread);              
            }
            foreach (var thread in SupplierThreads) thread.Join();

            for (int i = 0; i < 49; i++)
            {
                Thread thread = new Thread(() => shop.Buyers.ElementAt(i).CreateAndSendOrder(shop));
                thread.Start();
                BuyerThreads.Add(thread);
            }
            foreach (var thread in BuyerThreads) thread.Join();

            Thread last = new Thread(() => shop.BuyReport(shop));
            last.Start();
            last.Join();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
