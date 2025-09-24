namespace Bibliotheekbeheersysteem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            keuzeMenu();
        }

        public static void keuzeMenu()
        {
            bool active = true;

            Library bib = new Library("AP Bibliotheek");

            string[] options = ["", "", "", "", "", "", "", "", "Afsluiten"];
            do
            {
                Console.WriteLine("Keuze Menu");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {options[i]}");
                }
                Console.WriteLine();

                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Voer de titel in van het boek:");
                            Console.Write("> ");
                            string title = Console.ReadLine();

                            Console.WriteLine("Voer de auteur in van het boek:");
                            Console.Write("> ");
                            string author = Console.ReadLine();

                            Book book = new Book(bib, title, author);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            string[] extraOptions = ["Taal", "Genre", "Aantal Bladeren", "Doelgroep", "Samenvatting", "ISBN"];

                            for (int i = 0; i < extraOptions.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}: {extraOptions[i]}");
                            }
                            Console.WriteLine();

                            Console.Write("> ");
                            int extraChoice = Convert.ToInt32(Console.ReadLine());

                            switch (extraChoice)
                            {
                                case 1:
                                    break;

                                case 2:
                                    break;

                                case 3:
                                    break;

                                case 4:
                                    break;

                                case 5:
                                    break;

                                case 6:
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    default:
                        Console.WriteLine("bibliotheek applicatie afsluiten, Druk op Enter");
                        active = false;
                        Console.ReadKey();
                        break;
                }
            } while (active);
        }
    }
}