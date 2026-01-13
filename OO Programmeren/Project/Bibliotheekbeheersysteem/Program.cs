namespace Bibliotheekbeheersysteem
{
    internal class Program
    {
        private bool boekMenu = true;

        private static void Main(string[] args)
        {
            keuzeMenu();
        }

        public static void keuzeMenu()
        {
            bool mainMenu = true;//Menu loop variablen when true doorloop de do - while

            //vragen hoe de bib moet noemen;
            Console.WriteLine("Voer naam in van Bib");
            String bibName = Console.ReadLine() ?? "";
            Library bib = new Library(bibName); //geef naam aan Libary-Object

            string[] optionsMainMenu = ["Boeken", "Boekjes(Magazine,Krant)", "Afsluiten"];

            Program opt = new Program();

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Keuze Menu");

                    for (int i = 0; i < optionsMainMenu.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}: {optionsMainMenu[i]}");
                    }

                    Console.Write("> ");
                    string choice = Console.ReadLine() ?? "";

                    if(!int.TryParse(choice, out int libaryOption))
                    {
                        if(choice == "")
                        {
                            throw new ArgumentException("Kies een Optie");
                        }

                        throw new FormatException("Ingevoerde waarde is een tekst");
                    }
                    else
                    {
                        if(libaryOption > optionsMainMenu.Length)
                        {
                            throw new IndexOutOfRangeException("Optie staat niet in de lijst");
                        }
                    }


                        switch (libaryOption)
                        {
                            //boeken
                            case 1:

                                bib.BookMenu();

                                break;
                            //Magazine en klranten
                            case 2:
                                bib.KrantEnMagazineMenu();

                                break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Programma wordt afgesloten");
                            mainMenu = false;

                            Console.Write("Druk op Enter >");
                            Console.ReadKey();
                            break;
                        }
                }
                catch (Exception a)
                {
                    Console.WriteLine(a.Message);
                    Console.Write("Druk op Enter >");
                    Console.ReadLine();
                }
                
            } while (mainMenu)
            ;
        }
    }
}