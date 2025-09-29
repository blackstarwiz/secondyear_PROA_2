using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class ClassesAndObjects
    {
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
