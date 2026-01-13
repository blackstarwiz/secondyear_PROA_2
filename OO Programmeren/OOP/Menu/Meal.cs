using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Meal
    {
        private ConsoleColor randomColor;
        private Random rn = new Random();
        private string? name;
        private double price;

        public Meal(string name, double price)
        {
            int color = rn.Next(1, 15);
            randomColor = (ConsoleColor)color;
            Price = price;
            Name = name;
        }

        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Meal other && obj.GetType().Name == "ChildrenMeal";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.GetType().Name);
        }
        public void ShowTheMenu()
        {
            if (Equals(this))
            {
                Console.ForegroundColor = randomColor;
                Console.WriteLine($"{Name}\t\t\t{Price}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{Name}\t\t\t{Price}");
            }

        }
    }
}
