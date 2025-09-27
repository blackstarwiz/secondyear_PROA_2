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
            bool mainMenu = true;//Menu loop variablen when true doorloop de do - while

            Library bib = new Library("AP Bibliotheek"); //geef naam aan Libary-Object

            string[] options = ["Boek Toevoegen", "Extra Info Toevoegen", "Boek Zoeken -> (Titel,Auteur) ? Yes : No", "Bibliotheek Menu", "Boek Verwijderen", "Boeken Tonen", "CSV-Bestand In Lezen", "Afsluiten"];

            while (mainMenu)
            {
                Console.WriteLine("Keuze Menu");

                //print alle options uit om uit te kiezen
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {options[i]}");
                }
                Console.WriteLine();

                Console.Write("> ");
                int mainChoice = Convert.ToInt32(Console.ReadLine());

                //vanuit de choice variablen gaan de de juiste CASE kiezen
                switch (mainChoice)
                {
                    //book toevoegen
                    case 1:
                        try
                        {
                            //vragen de gebruiker om title en author in te voeren
                            Console.WriteLine("Voer de titel in van het boek:");
                            Console.Write("> ");
                            string title = Console.ReadLine();

                            Console.WriteLine("Voer de auteur in van het boek:");
                            Console.Write("> ");
                            string author = Console.ReadLine();

                            //we maken een book object aan via contructor (overloads)
                            //we geven bib object mee om het boek direct in de juist Library toe te voegen
                            Book book = new Book(bib, title, author);
                        }
                        //we vangen exeptions op die binnen de klasses Book en Library zouden throwen
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    //Extra Info toevoegen aan book object
                    case 2:
                        try
                        {
                            bool boekMenu = true;
                            bool infoMenu = true;

                            while (boekMenu)
                            {
                                //print de lijst van het Library Object -> list<Books> -> Title
                                for (int i = 0; i < bib.Books.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}: {bib.Books[i].Title}");
                                }
                                Console.WriteLine();

                                Console.Write("> ");
                                int choicenBook = Convert.ToInt32(Console.ReadLine());

                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine(bib.Books[choicenBook].Title);
                                    Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook].Title.Length, '*'));

                                    string[] infoOptions = ["Taal", "Genre", "Aantal Bladeren", "Doelgroep", "Samenvatting", "ISBN", "Boek Wisselen"];

                                    for (int i = 0; i < infoOptions.Length; i++)
                                    {
                                        Console.WriteLine($"{i + 1}: {infoOptions[i]}");
                                    }
                                    Console.WriteLine();

                                    Console.Write("> ");
                                    int infoChoice = Convert.ToInt32(Console.ReadLine());

                                    switch (infoChoice)
                                    {
                                        case 1:
                                            try
                                            {
                                                Console.Clear();

                                                Console.WriteLine(bib.Books[choicenBook].Title);
                                                Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook].Title.Length, '*'));

                                                Console.WriteLine("Voer taal in: ");

                                                Console.WriteLine();

                                                Console.Write("> ");
                                                bib.Books[choicenBook].Language = Console.ReadLine();
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            }

                                            break;

                                        case 2:
                                            try
                                            {
                                                Console.Clear();

                                                Console.WriteLine(bib.Books[choicenBook].Title);
                                                Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook].Title.Length, '*'));

                                                Console.WriteLine("Voer Genre in: ");

                                                Console.WriteLine();

                                                Console.Write("> ");
                                                bib.Books[choicenBook].Genre = Console.ReadLine();
                                            }
                                            catch(Exception e)
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

                                        default:
                                            infoMenu = false;
                                            break;
                                    }
                                    ;
                                } while (infoMenu);
                            }
                            ;
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

                    default:
                        Console.WriteLine("bibliotheek applicatie afsluiten, Druk op Enter");
                        mainMenu = false;
                        Console.ReadKey();
                        break;
                }
                ;
            }
            ;
        }
    }
}