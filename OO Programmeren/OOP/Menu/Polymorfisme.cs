namespace Menu
{
    internal class Polymorfisme
    {
        private bool active = true;
        private string[] polymorfismeMenu = ["h17-autoconstructeur", "Terug naar hoofdmenu"];

        public static void ShowSubMenu()
        {
            Polymorfisme menu = new();
            do
            {
                Console.Clear();

                for (int i = 0; i < menu.polymorfismeMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {menu.polymorfismeMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        break;

                    default:
                        if (choice == menu.polymorfismeMenu.Length)
                        {
                            menu.active = false;
                        }
                        else
                        {
                            Console.WriteLine("Gekozen optie staat niet in de lijst!, Klikt op Enter");
                            Console.Write("> ");
                            Console.ReadLine();
                        }
                        break;
                }
                if(choice <= menu.polymorfismeMenu.Length - 1)
                {
                    Console.WriteLine("Druk op enter om terug te naar polymofisme menu te gaan");
                    Console.Write("> ");
                    Console.ReadKey();
                }
            } while (menu.active);
        }
    }
}