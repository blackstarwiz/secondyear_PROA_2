namespace Bibliotheekbeheersysteem
{
    internal class Program
    {
        private bool boekMenu = true;
        private bool infoMenu = true;
        private bool deleteMenu = true;
        

        private static void Main(string[] args)
        {
            keuzeMenu();
        }

        public static void keuzeMenu()
        {
            bool mainMenu = true;//Menu loop variablen when true doorloop de do - while

            Library bib = new Library("AP Bibliotheek"); //geef naam aan Libary-Object

            string[] options = ["Boek Toevoegen", "Extra Info Toevoegen", "Boek Zoeken -> (Titel,Auteur) ? Yes : No", "Bibliotheek Menu", "Boek Verwijderen", "Boeken Tonen", "CSV-Bestand In Lezen", "Afsluiten"];

            Program opt = new Program();

            while (mainMenu)
            {
                Console.Clear();
                Console.WriteLine("Keuze Menu");
                int mainChoice;

                // print alle options uit om uit te kiezen
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
                    //Als invoer niet een interger is zal  mainChoic 0 worden
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
                            while (opt.boekMenu)
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

                                    //GEKOZEN BOEK TONEN
                                    Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                    Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                    //Array van opties  voor extra info
                                    string[] infoOptions = ["Terug", "Taal", "Genre", "Aantal Bladeren", "Doelgroep", "Samenvatting", "ISBN", "Boek Wisselen"];

                                    for (int i = 0; i < infoOptions.Length; i++)
                                    {
                                        Console.WriteLine($"{i}: {infoOptions[i]}");
                                    }
                                    Console.WriteLine();

                                    Console.Write("> ");
                                    string inputInfo = Console.ReadLine();

                                    //Checken of invoer interger is
                                    if (int.TryParse(inputInfo, out int resultInfo))
                                    {
                                        infoChoice = resultInfo;
                                    }
                                    else
                                    {
                                        //Als het niet een int is geef -1 mee
                                        infoChoice = -1;
                                    }

                                    switch (infoChoice)
                                    {
                                        case -1:
                                            Console.WriteLine("input is een string, voer beschikbare optie in!\nDruk op enter");
                                            Console.Write(">");
                                            Console.ReadKey();
                                            opt.infoMenu = false;
                                            break;
                                        //Terug
                                        case 0:
                                            opt.boekMenu = false;
                                            opt.infoMenu = false;
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
                                                bool genreInput = true;
                                                do
                                                {
                                                    Console.Clear();

                                                    Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                                    Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));

                                                    Console.WriteLine("Voer Genre in: ");

                                                    Console.WriteLine();

                                                    Console.Write("> ");

                                                    try
                                                    {
                                                        bib.Books[choicenBook - 1].Genre = Console.ReadLine();
                                                        genreInput = false;
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }

                                                    Console.WriteLine("Druk op enter:");
                                                    Console.Write(">");
                                                    Console.ReadKey();
                                                } while (genreInput);
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

                                            Console.WriteLine("Voer aantal bladzijdes in: ");

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

                                            Console.WriteLine("Voer samenvatting in: ");

                                            Console.WriteLine();

                                            Console.Write("> ");
                                            bib.Books[choicenBook - 1].Summary = Console.ReadLine();
                                            break;
                                        //ISBN
                                        case 6:

                                            bool isbninput = true;
                                            do
                                            {
                                                Console.Clear();

                                                Console.WriteLine(bib.Books[choicenBook - 1].Title);
                                                Console.WriteLine(String.Empty.PadRight(bib.Books[choicenBook - 1].Title.Length, '*'));//--------

                                                Console.WriteLine("Voer ISBN in: ");
                                                Console.WriteLine();

                                                Console.Write("> ");
                                                try
                                                {
                                                    bib.Books[choicenBook - 1].ISBN = Console.ReadLine();
                                                    Console.WriteLine("ISBN nummer is toegvoegd!!");
                                                    isbninput = false;
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }

                                                Console.WriteLine("Druk op enter:");
                                                Console.Write(">");
                                                Console.ReadKey();
                                            } while (isbninput);
                                            break;

                                        //ander boek kiezen
                                        case 7:

                                            opt.infoMenu = false;
                                            break;
                                        //letters ingevoerd
                                        case > 8:
                                            Console.WriteLine("Optie staat niet in de lijst, voer beschikbare optie in!\nDruk op enter");
                                            Console.Write(">");
                                            Console.ReadKey();

                                            break;
                                    }
                                    ;
                                } while (opt.infoMenu);
                            }
                            ;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    //Boek zoeken met title of auteur
                    case 3:
                        try
                        {
                            bib.FindBookAuthAndTitle();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine("Druk op enter");
                        Console.Write("> ");
                        Console.ReadKey();

                        break;
                    //Bibliotheek Menu
                    case 4:

                        break;
                    //Boek Verwijderen
                    case 5:
                        do
                        {
                            try
                            {
                                bib.DeleteBook();
                                opt.deleteMenu = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);

                                Console.WriteLine();
                                Console.WriteLine("Druk op enter");
                                Console.Write("> ");
                                Console.ReadKey();
                            }
                        } while (opt.deleteMenu);

                        break;
                    //Boeken Tonen
                    case 6:
                        Console.Clear();
                        int counter = 0;
                        string word = "Toon Boeken";

                        Console.WriteLine(word);
                        Console.WriteLine(string.Empty.PadRight(word.Length, '*'));

                        foreach (Book book in bib.Books)
                        {
                            Console.WriteLine($"{++counter}: {book.Title}");
                        }
                        Console.WriteLine("Druk op enter");
                        Console.Write("> ");
                        Console.ReadKey();
                        break;
                    //CSV - Bestand In Lezen
                    case 7:
                        bib.CsvFileReader();
                        Console.ReadKey();
                        break;
                    //aflsuiten van applicatie
                    case 8:
                        Console.WriteLine("bibliotheek applicatie afsluiten, Druk op Enter");
                        mainMenu = false;
                        Console.ReadKey();
                        break;
                    //optie die niet in de lijst staan
                    case > 8:
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