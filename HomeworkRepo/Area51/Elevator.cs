using System;
using System.Collections.Generic;
using System.Threading;
using static Area51.Base;

namespace Area51
{
    public class Elevator : Base
    {
        public Floors CurrentFloor { get; set; }
        public List<Agent> Agents { get; set; }
        public bool DoorOpened { get; set; }
        public Base Area51 { get; set; }
        public enum FloorButtons { G, S, T1, T2 };

        public void SetFloor (Floors value)
        {
            CurrentFloor = value;
        }

        public Floors GetFloor ()
        {
            return CurrentFloor;
        }

        public bool ButtonPressed { get; set; }

        public Elevator(Base area51)
        {
            Area51 = area51;
            Agents = new List<Agent>();
            SetFloor(Floors.G);
        }
    }
}
