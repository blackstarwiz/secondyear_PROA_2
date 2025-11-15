using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class ExeptionHandeling
    {
        private bool active = true;
        private string[] exeptionHandelingMenu = ["h16-weekdagen-zonder-exception-handling", "h16-weekdagen-met-exception-handling", "Terug naar hoofdmenu"];

        public static void ShowSubMenu()
        {
            ExeptionHandeling menu = new ExeptionHandeling();
            do
            {
                Console.Clear();
                for (int i = 0; i < menu.exeptionHandelingMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{menu.exeptionHandelingMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        DemonstreerFoutafhandelingWeekdagenZonderException();
                        break;

                    case 2:

                        DemonstreerFoutafhandelingWeekdagenMetException();
                        
                        break;

                    default:
                        if (choice == menu.exeptionHandelingMenu.Length)
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
                if (choice <= menu.exeptionHandelingMenu.Length - 1)
                    Console.ReadKey();
            } while (menu.active);
        }

        private static void DemonstreerFoutafhandelingWeekdagenZonderException()
        {
            string[] arr = new string[5];
            arr[0] = "Vrijdag";
            arr[1] = "Maandag";
            arr[2] = "Dinsdag";
            arr[3] = "Woensdag";
            arr[4] = "Donderdag";

            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine(arr[i].ToString());
            }
        }

        private static void DemonstreerFoutafhandelingWeekdagenMetException()
        {
            string[] arr = new string[5];
            arr[0] = "Vrijdag";
            arr[1] = "Maandag";
            arr[2] = "Dinsdag";
            arr[3] = "Woensdag";
            arr[4] = "Donderdag";

            try
            {
                checked
                {
                }
            }
            catch (OverflowException e)
            {
            }

            for (int i = 0; i <= arr.Length; i++)
            {
                Console.WriteLine(arr[i].ToString());
            }
        }
    }
}