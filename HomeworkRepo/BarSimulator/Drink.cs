using System;
namespace BarSimulator
{
    public class Drink
    {   
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Drink(double price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}

