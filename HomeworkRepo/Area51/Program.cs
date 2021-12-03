using System;
using System.Collections.Generic;
using System.Threading;

namespace Area51
{
    class Program
    {
        static void Main(string[] args)
        {
            Base Area51 = new Base();
            Elevator elevator = new Elevator(Area51);
            List<Thread> agentThreads = new List<Thread>();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                var agent = new Base.Agent(i.ToString());
                var thread = new Thread(agent.ChooseFloor);
                thread.Start();
                agentThreads.Add(thread);
            }

            foreach (var agent in agentThreads)
            {
                agent.Join();
            }

        }
    }
}
