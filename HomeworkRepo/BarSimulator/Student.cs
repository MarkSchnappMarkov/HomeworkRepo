    using System;
using System.Threading;

namespace BarSimulator
{
    public class Student
    {
        enum NightlifeActivities { Walk, VisitBar, GoHome };
        enum BarActivities { Drink, Dance, Leave };

        Random random = new Random();

        public string Name { get; set; }
        public int Age { get; set; }
        public Bar Bar { get; set; }
        public double Budget { get; set; }

        private NightlifeActivities GetRandomNightlifeActivity()
        {
            int n = random.Next(10);
            if (n < 3) return NightlifeActivities.Walk;
            if (n < 8) return NightlifeActivities.VisitBar;
            return NightlifeActivities.GoHome;
        }

        private BarActivities GetRandomBarActivity()
        {
            int n = random.Next(10);
            if (n < 4) return BarActivities.Dance;
            if (n < 9) return BarActivities.Drink;
            return BarActivities.Leave;
        }

        private void WalkOut()
        {
            Console.WriteLine($"{Name} is walking in the streets.");
            Thread.Sleep(100);
        }

        private void VisitBar()
        {
            if (Bar.Open)
            {
                Console.WriteLine($"{Name} is getting in the line to enter the bar.");
                Bar.Enter(this);
                Console.WriteLine($"{Name} entered the bar!");
                bool staysAtBar = true;
                while (staysAtBar)
                {
                    var nextActivity = GetRandomBarActivity();
                    switch (nextActivity)
                    {
                        case BarActivities.Dance:
                            Console.WriteLine($"{Name} is dancing.");
                            Thread.Sleep(100);
                            break;
                        case BarActivities.Drink:
                            Console.WriteLine($"{Name} is drinking.");
                            Thread.Sleep(100);
                            break;
                        case BarActivities.Leave:
                            Console.WriteLine($"{Name} is leaving the bar.");
                            Bar.Leave(this);
                            staysAtBar = false;
                            break;
                        default: throw new NotImplementedException();
                    }
                }
            }
        }

        public void PaintTheTownRed()
        {
            WalkOut();
            bool staysOut = true;
            while (staysOut)
            {
                var nextActivity = GetRandomNightlifeActivity();
                switch (nextActivity)
                {
                    case NightlifeActivities.Walk:
                        WalkOut();
                        break;
                    case NightlifeActivities.VisitBar:
                        VisitBar();
                        staysOut = false;
                        break;
                    case NightlifeActivities.GoHome:
                        staysOut = false;
                        break;
                    default: throw new NotImplementedException();
                }
            }
            Console.WriteLine($"{Name} is going back home.");
        }

        public Student(string name, Bar bar)
        {
            Name = name;
            Age = random.Next(16, 30);
            Bar = bar;
            Budget = random.Next(50, 500);
        }
    }
}

