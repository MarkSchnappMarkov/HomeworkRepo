using System;
using System.Collections.Generic;
using System.Threading;
using BarSimulator;

Bar bar = new Bar();
List<Thread> studentThreads = new List<Thread>();
Random random = new Random();

for (int i = 1; i < 100; i++)
{
    var student = new Student(i.ToString(), bar);
    var thread = new Thread(student.PaintTheTownRed);
    thread.Start();
    studentThreads.Add(thread);
}

foreach (var t in studentThreads)
{
    if (bar.Open)
    {
        if (random.Next(1, 30) < 5)
        {
            bar.Close();
        }
    }
    t.Join();
}

Console.WriteLine();
Console.WriteLine("The party is over.");
Console.ReadLine();