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

            List<Thread> starterThreads = new List<Thread>();
            List<Thread> threads = new List<Thread>();

            Thread first = new Thread(shop.LaunchTheStore);
            first.Priority = ThreadPriority.Highest;

            Thread second = new Thread(() => shop.Suppliers.ElementAt(0).LoadItemsToStorage(shop));
            second.Priority = ThreadPriority.AboveNormal;

            starterThreads.Add(first);
            starterThreads.Add(second);

            foreach (var thread in starterThreads) thread.Start();
            foreach (var thread in starterThreads) thread.Join();

            for (int i = 1; i < 3; i++)
            {
                Thread thread = new Thread(() => shop.Suppliers.ElementAt(i).LoadItemsToStorage(shop));
                thread.Priority = ThreadPriority.Normal;
                threads.Add(thread);
            }

            for (int i = 0; i <= 49; i++)
            {
                Thread thread = new Thread(() => shop.Buyers.ElementAt(i).CreateAndSendOrder(shop));
                thread.Priority = ThreadPriority.Normal;
                threads.Add(thread);
            }

            Thread last = new Thread(() => shop.BuyReport(shop));
            last.Priority = ThreadPriority.Lowest;
            threads.Add(last);

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);

        }

    }
}
