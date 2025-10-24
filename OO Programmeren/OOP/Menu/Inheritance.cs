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
        private string[] inhertanceMenu = ["PostOffice", "Veterinarian","Terug naar hoofdmenu"];
        public static void ShowSubMenu()
        {
            Inheritance menu = new Inheritance();
            do
            {
                
                for (int i = 0; i < menu.inhertanceMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{menu.inhertanceMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisteredLetter postOffice = new RegisteredLetter();

                        postOffice.DemoPostOffice();
                        break;
                    case 2:
                        Animal.DemoVet();
                        break;
                    default:
                        menu.active = false;
                        break;
                }
            } while (menu.active);
        }
    }
}
