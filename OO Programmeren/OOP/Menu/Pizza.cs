using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal abstract class Pizza
    {
        private List<string> Ingredients;

        public Pizza(string[] extraToppings)
        {
            if (Equals(this))
            {
                this.Ingredients = new List<string> { "deeg", "tomatensaus", "kaas" };
            }
            else
            {
                this.Ingredients = new List<string> { "deeg", "tomatensaus" };
            }

            foreach (var topping in extraToppings)
            {
                this.Ingredients.Add(topping);
            }
        }

        public abstract double UnitPrice
        {
            get;
        }

        public double Price
        {
            get
            {
                return this.UnitPrice + (this.Ingredients.Count * 0.5);
            }
        }

        public void ShowIngredients()
        {
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Pizza pizza && obj.GetType().Name == "Margerita";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.GetType().Name);
        }

        
    }
}