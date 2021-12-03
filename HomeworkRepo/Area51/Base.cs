using System;
using System.Threading;

namespace Area51
{
    
    public class Base
    {
        public enum Floors { G, S, T1, T2 };

        public string Name { get; set; }

        public Base()
        {
            Name = "Area 51";
        }

        public class Agent
        {
            Random random = new Random();
            public string AgentName { get; set; }
            public enum SecurityLevel { Confidential, Secret, TopSecret }
            public SecurityLevel SecurityPass { get; set; }
            public Floors ChosenFloor { get; set; }
            public Floors CurrentFloor { get; set; }

            public void ChooseFloor()
            {
                Console.WriteLine($"{AgentName} is floor: {CurrentFloor.ToString()}");
                int n = random.Next(1, 4);

                if (n == 1)
                {
                    ChosenFloor = Base.Floors.G;
                    Console.WriteLine($"{AgentName} want to go to floor {ChosenFloor.ToString()}");
                }
                else if (n == 2)
                {
                    ChosenFloor = Base.Floors.S;
                    Console.WriteLine($"{AgentName} want to go to floor {ChosenFloor.ToString()}");
                }
                else if (n == 3)
                {
                    ChosenFloor = Base.Floors.T1;
                    Console.WriteLine($"{AgentName} want to go to floor {ChosenFloor.ToString()}");
                }
                else if (n == 4)
                {
                    ChosenFloor = Base.Floors.T2;
                    Console.WriteLine($"{AgentName} want to go to floor {ChosenFloor.ToString()}");
                }
            }

            public void GetSecurityPass()
            {
                int n = random.Next(1, 3);

                if (n == 1)
                {
                    SecurityPass = SecurityLevel.Confidential;
                }
                else if (n == 2)
                {
                    SecurityPass = SecurityLevel.Secret;
                }
                else if (n == 3)
                {
                    SecurityPass = SecurityLevel.TopSecret;
                }
            }

            public Agent(string name)
            {
                AgentName = name;
                CurrentFloor = Base.Floors.G;
                GetSecurityPass();
            }
        }
    }
}
