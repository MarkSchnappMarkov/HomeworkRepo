using System;
using System.Collections.Generic;
using System.Threading;

namespace BarSimulator
{
    public class Bar
    {
        public List<Student> students = new List<Student>();
        Semaphore semaphore = new Semaphore(10, 10);
        public bool Open { get; set; }

        public Bar()
        {
            Open = true;
        }

        public void Enter(Student student)
        {
            if (Open)
            {
                semaphore.WaitOne();
                lock (students)
                {
                    if (student.Age >= 18)
                    {
                        students.Add(student);
                    }
                    else
                    {
                        Console.WriteLine("TOOOOOOOOOOOOOO YOUNG");
                    }
                }
            }   
        }

        public void Leave(Student student)
        {
            lock (students)
            {
                students.Remove(student);
            }
            semaphore.Release();
        }

        public void Close()
        {
            Open = false;
            Console.WriteLine("THE BAR CLOSED, NOBODY CAN ENTER ANYMORE");
        }

    }
}

