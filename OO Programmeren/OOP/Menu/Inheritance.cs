using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Menu
{
    internal class Inheritance
    {
        private bool active = true;
        private string[] inhertanceMenu = ["PostOffice", "Veterinarian", "DemoOrders", "DemoPizzas", "DemoMeals", "Terug naar hoofdmenu"];

        public static void ShowSubMenu()
        {
            Inheritance menu = new Inheritance();
            do
            {
                Console.Clear();
                for (int i = 0; i < menu.inhertanceMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{menu.inhertanceMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();


                switch (choice)
                {
                    case 1:
                        RegisteredLetter postOffice = new RegisteredLetter();

                        postOffice.DemoPostOffice();
                        break;

                    case 2:
                        Animal.DemoVet();
                        break;

                    case 3:
                        DemoOrders();
                        break;

                    case 4:
                        DemoPizzas();
                        break;
                    case 5:
                        DemoMeals();
                        break;

                    default:
                        menu.active = false;
                        break;
                }
            } while (menu.active);
        }

        public static void DemoOrders()
        {
            Console.Clear();

            Console.WriteLine("Hoeveel stuks?");
            Console.Write("> ");

            uint number = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Basisprijs?");
            int unitPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Gewone bestelling (1) of internationale bestelling (2)?");

            int choice = Convert.ToInt32(Console.ReadLine());

            Order bestelling = choice switch
            {
                1 => new Order(number, unitPrice),
                2 => new InternationalOrder(number, unitPrice),
                _ => throw new ArgumentException("Ongeldige keuze")
            };

            Console.WriteLine($"TotaalPrijs: {bestelling.TotalPrice.ToString()}");

            Console.ReadKey();
        }

        public static void DemoPizzas()
        {
            Margerita pizza1 = new Margerita(["Mozzaarella"]);
            Veggie pizza2 = new Veggie(["tofu", "spinazie"]);

            Console.WriteLine($"Een margarita zonder extra's kost: {pizza1.UnitPrice}");
            Console.WriteLine("De ingredienten zijn:");
            pizza1.ShowIngredients();
            
            Console.WriteLine();

            Console.WriteLine($"Een margarita zonder extra's kost: {pizza2.UnitPrice}");
            Console.WriteLine("De ingredienten zijn:");
            pizza2.ShowIngredients();

            Console.Write("Press Enter> ");
            Console.ReadKey();
        }

        public static void DemoMeals()
        {
            Meal meal1 = new Meal("Paling in 't groen",2.8);
            ChildrenMeal meal2 = new ChildrenMeal("Kinder Vol-au-vent", 2.5);
            Meal meal3 = new Meal("Waterzooi", 3.2);
            ChildrenMeal meal4 = new ChildrenMeal("Kabouterschnitzel", 2.1);

            meal1.ShowTheMenu();
            meal2.ShowTheMenu();
            meal3.ShowTheMenu();
            meal4.ShowTheMenu();

            Console.Write("Press Enter> ");
            Console.ReadKey();
        }
    }
}