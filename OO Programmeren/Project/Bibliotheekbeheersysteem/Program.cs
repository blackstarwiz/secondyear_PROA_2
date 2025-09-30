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
                Console.Clear();
                Console.WriteLine("Keuze Menu");
                int mainChoice;

                //print alle options uit om uit te kiezen
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {options[i]}");
                }
                Console.WriteLine();

                Console.Write("> ");
                string inputUser = Console.ReadLine();

                /*
                                    we gaan inputUser testen op int value,
                                    de input wordt geparsed als deze blijkt een cijfer te zijn
                                    zal deze meegegeven worden aan mainChoice
                              */
                if (int.TryParse(inputUser, out int result))
                {
                    mainChoice = result;
                }
                else
                {
                    mainChoice = 0;
                }

                //vanuit de choice variablen gaan de de juiste CASE kiezen
                switch (mainChoice)
                {
                    //Letter ingevoerd
                    case 0:

                        Console.WriteLine("input is een string, voer beschikbare optie in!\nDruk op enter");
                        Console.Write(">");
                        Console.ReadKey();

                        break;
                    //boek toevoegen
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
                                    int infoChoice;
                                    Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                    Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                    string[] infoOptions = ["Terug", "Taal", "Genre", "Aantal Bladeren", "Doelgroep", "Samenvatting", "ISBN", "Boek Wisselen"];

                                    for (int i = 0; i < infoOptions.Length; i++)
                                    {
                                        Console.WriteLine($"{i}: {infoOptions[i]}");
                                    }
                                    Console.WriteLine();

                                    Console.Write("> ");
                                    string inputInfo = Console.ReadLine();

                                    if (int.TryParse(inputInfo, out int resultInfo))
                                    {
                                        infoChoice = resultInfo;
                                    }
                                    else
                                    {
                                        infoChoice = -1;
                                    }

                                    switch (infoChoice)
                                    {
                                        case -1:
                                            Console.WriteLine("input is een string, voer beschikbare optie in!\nDruk op enter");
                                            Console.Write(">");
                                            Console.ReadKey();
                                            break;
                                        //Terug
                                        case 0:
                                            boekMenu = false;
                                            infoMenu = false;
                                            break;
                                        //Taal
                                        case 1:
                                            try
                                            {
                                                Console.Clear();

                                                Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                                Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//-----

                                                Console.WriteLine("Voer taal in: ");

                                                Console.WriteLine();

                                                Console.Write("> ");
                                                bib.Books[choicenBook - 1].Language = Console.ReadLine();
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            }

                                            break;
                                        //Genre
                                        case 2:
                                            try
                                            {
                                                Console.Clear();

                                                Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                                Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                                Console.WriteLine("Voer Genre in: ");

                                                Console.WriteLine();

                                                Console.Write("> ");
                                                bib.Books[choicenBook - 1].Genre = Console.ReadLine();
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            }
                                            break;
                                        //Pages
                                        case 3:
                                            Console.Clear();

                                            Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                            Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                            Console.WriteLine("VoerAantal Bladzijdes in: ");

                                            Console.WriteLine();

                                            Console.Write("> ");
                                            bib.Books[choicenBook - 1].Pages = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        //Traget_Group
                                        case 4:
                                            Console.Clear();

                                            Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                            Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                            Console.WriteLine("Voer doelgroep in: ");

                                            Console.WriteLine();

                                            Console.Write("> ");
                                            bib.Books[choicenBook - 1].Target_Group = Console.ReadLine();
                                            break;
                                        //Summary
                                        case 5:
                                            Console.Clear();

                                            Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                            Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                            Console.WriteLine("Voer Samenvatting in: ");

                                            Console.WriteLine();

                                            Console.Write("> ");
                                            bib.Books[choicenBook - 1].Summary = Console.ReadLine();
                                            break;
                                        //ISBN
                                        case 6:
                                            Console.Clear();

                                            Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                            Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                            Console.WriteLine("Voer Genre in: ");

                                            Console.WriteLine();

                                            Console.Write("> ");
                                            bib.Books[choicenBook - 1].ISBN = Console.ReadLine();
                                            break;

                                        //ander boek kiezen
                                        case 7:

                                            infoMenu = false;
                                            break;
                                        //letters ingevoerd
                                        case > 8:
                                            Console.WriteLine("Optie staat niet in de lijst, voer beschikbare optie in!\nDruk op enter");
                                            Console.Write(">");
                                            Console.ReadKey();

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

                    case 8:
                        Console.WriteLine("bibliotheek applicatie afsluiten, Druk op Enter");
                        mainMenu = false;
                        Console.ReadKey();
                        break;

                   case >8:
                        Console.WriteLine("Keuze staat niet in de lijst, voer beschikbare optie in!\nDruk op enter");
                        Console.Write(">");
                        Console.ReadKey();
                        break;
                }
                ;
            }
            ;
        }
    }
}