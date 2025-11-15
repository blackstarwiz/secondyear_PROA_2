using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class ClassesAndObjects
    {

        private bool active = true;
        private string[] classObjectsMenu = ["H11-FiguresWithConstructor", "H11-FoodPurchase", "Terug naar Hoofdmenu"];

        public static void ShowSubMenu()
        {
            ClassesAndObjects menu = new ClassesAndObjects();
            do
            {
                Console.Clear();
                for (int i = 0; i < menu.classObjectsMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{menu.classObjectsMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();


                switch (choice)
                {
                    case 1:
                       DemoFigures();
                        break;
                    case 2:
                        try
                        {
                            FoodPurchase.DemoPurchase();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    default:
                        if (choice == menu.classObjectsMenu.Length)
                        {
                            menu.active = false;
                        }
                        else
                        {
                            Console.WriteLine("Ingevoerde keuze staat niet in de lijst, Klik op Enter");
                            Console.ReadKey();
                        }


                        break;
                }
                if(choice <= menu.classObjectsMenu.Length - 1)
                    Console.ReadKey();
            } while (menu.active);
        }



        public static void DemoFigures()
        {
            bool figMenu = true;

            Rectangle rectangle = new Rectangle(1.0, 1.0);
            Triangle triangle = new Triangle(1.0, 1.0);

            do
            {
                Console.WriteLine("Voer afmetingen in: Vb.(1.25)");

                Console.WriteLine("RechtHoek:");
                Console.WriteLine("Breedte");
                Console.Write("> ");
                double width = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Hoogte");
                Console.Write("> ");
                double height = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("DrieHoek:");
                Console.WriteLine("Basis");
                Console.Write("> ");
                double @base = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Hoogte");
                Console.Write("> ");
                double heightTri = Convert.ToDouble(Console.ReadLine());


                try
                {
                    rectangle.Width = width;
                    rectangle.Height = height;

                    triangle.Base = @base;
                    triangle.Height = heightTri;

                    Console.WriteLine($"Een rechthoek met breede van {width}m en een hoogte van {height} heeft een oppervlakte van {rectangle.Area}m²");
                    Console.WriteLine($"Een driehoek met een basis van {@base}m en een hoogte van {heightTri}m heeft een oppervlakte van {triangle.Area}m²");
                    figMenu = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (figMenu);
        }
    }
}
