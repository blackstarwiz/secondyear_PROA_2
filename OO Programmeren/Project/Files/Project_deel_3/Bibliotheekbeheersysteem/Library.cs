using System.Globalization;
using System.Text.RegularExpressions;

namespace Bibliotheekbeheersysteem
{
    internal class Library
    {
        private bool infoBoekMenu = true;
        private bool readingRoomMenu = true;

        //private bool deleteMenu = true;
        private bool infoMenu = true;

        private string nameLibary;
        private List<Book> books = new List<Book>().ToList();
        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();
        private string[] optionsBook = ["Boek Toevoegen", "Extra Info Toevoegen", "Boek Zoeken -> (Titel,Auteur) ? Yes : No", "Bibliotheek Menu", "Boek Verwijderen", "Boeken Tonen", "CSV-Bestand In Lezen", "Boek Uitlenen", "Boek terug brengenn", "Terug"];
        private string[] optionsReadingItems = ["Krant tevoegen", "Magazine Toevoegen", "Alle kranten tonen", "Alle magazines tonen", "aanwinsten leesruimte", "Terug"];

        public Library(string name)
        {
            if (name == "")
            {
                NameLibary = "ApHogeschool";
                return;
            }

            this.NameLibary = name;
        }

        private string NameLibary
        {
            get
            {
                return nameLibary;
            }
            set
            {
                nameLibary = value;
            }
        }

        public List<Book> Books
        {
            get
            {
                return books;
            }
        }

        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoom
        {
            get
            {
                return allReadingRoom;
            }
        }

        public void BookMenu()
        {
            bool bookMenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Boek Menu");

                // print alle options uit om uit te kiezen
                for (int i = 0; i < optionsBook.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {optionsBook[i]}");
                }
                Console.WriteLine();

                Console.Write("> ");
                string choice = Console.ReadLine() ?? "";

                try
                {
                    if (!int.TryParse(choice, out int bookOption))
                    {
                        if (choice == "")
                            throw new ArgumentException("Druk op Enter: ");
                        throw new Exception("Ingevoerde waarde is een tekst");
                    }
                    else
                    {
                        if (bookOption > optionsBook.Length)
                        {
                            throw new IndexOutOfRangeException("Optie staat niet in de lijst");
                        }
                    }

                    switch (bookOption)
                    {
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

                                Book book = new Book(this, title, author);
                            }
                            //we vangen exeptions op die binnen de klasses Book en Library zouden throwen
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.Write("Druk Enter >");
                                Console.ReadKey();
                            }
                            break;
                        //Extra Info toevoegen aan book object
                        case 2:
                            try
                            {
                                InfoBookMenu();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.Write("Druk op Enter >");
                                Console.ReadKey();
                            }
                            break;
                        //Boek zoeken met title of auteur
                        case 3:
                            FindBookAuthAndTitle();
                            break;
                        //thisliotheek Menu
                        case 4:
                            throw new ArgumentException("Nog te doen");
                        //Boek Verwijderen
                        case 5:

                            DeleteBook();

                            break;
                        //Boeken Tonen
                        case 6:
                            Console.Clear();
                            int counter = 0;
                            string word = "Toon Boeken";

                            Console.WriteLine(word);
                            Console.WriteLine(string.Empty.PadRight(word.Length, '*'));

                            foreach (Book book in this.Books)
                            {
                                Console.WriteLine($"{++counter}: {book.Title}");
                            }
                            Console.ReadKey();
                            break;
                        //CSV - Bestand In Lezen
                        case 7:
                            CsvFileReader();
                            Console.ReadKey();
                            break;

                        case 8:
                            BorrowBook();
                            break;

                        case 9:
                            ReturnBook();
                            break;
                        //terug gaan
                        default:
                            bookMenu = false;

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Druk op Enter >");
                    Console.ReadLine();
                }
            } while (bookMenu);
        }

        internal void ReturnBook()
        {
            if (Books.Count == 0)//als er nog geen boeken zijn
                throw new IndexOutOfRangeException("Er zijn nog geen boeken om in te leveren");

            bool chooseBook = true;
            int chosenBook = -1;
            bool borrowedBooks = false;
            //--------------------- Do While, Boek kiezen ------------------------------//
            do
            {
                Console.Clear();//blad leeg

                Console.WriteLine("0: Terug gaan");//toon extra optie

                //Alle books in this tonen
                for (int i = 0; i < Books.Count; i++)
                {
                    if (!Books[i].IsAvailable)//Als boek is uitgeleend toon het boek
                    {
                        borrowedBooks = true;
                        Console.WriteLine($" {i + 1}: {Books[i].Title}, {Books[i].IsAvailable}");
                    }
                }

                if (!borrowedBooks)
                {
                    Console.Clear();
                    throw new ArgumentException("Er zijn nog geen boeken uitgeleend");
                }

                Console.WriteLine();

                Console.Write("> ");

                string option = Console.ReadLine() ?? ""; //vraag optie

                try
                {
                    if (!int.TryParse(option, out int choicenOption))
                    {
                        if (option == "")//Als er  niets is ingevoerd

                            throw new ArgumentException("Kies een Optie");//als niet is ingevoerd

                        throw new FormatException("Ingvoerde waarde is een tekst");//Als een string is ingevoerd
                    }
                    else if (choicenOption > Books.Count + 1)//Als keuze buiten de aantal keuzens gaan
                    {
                        throw new IndexOutOfRangeException("Ingevoerde waarde staat is er niet!");
                    }

                    chosenBook = choicenOption;//als ingevoerde waarde een int is
                    chooseBook = false;//we verlaten dan de loop met books
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Druk op Enter >");
                    Console.ReadLine();
                }
            } while (chooseBook);//als boek gekozen is stoppen we de loop

            if (chosenBook == 0)
            {
                return;
            }
            else
            {
                Books[chosenBook - 1].IsAvailable = true;//zet beschikbaarheid op true
                Books[chosenBook - 1].BorrowingDate = new DateTime();//zet start datum
            }
        }

        internal void BorrowBook()
        {
            if (Books.Count == 0)//als er nog geen boeken zijn
                throw new IndexOutOfRangeException("Er zijn nog geen boeken om uit te lenen");

            bool chooseBook = true;
            int chosenBook = -1;
            //--------------------- Do While, Boek kiezen ------------------------------//
            do
            {
                Console.Clear();//blad leeg

                Console.WriteLine("0: Terug gaan");//toon extra optie

                //Alle books in this tonen
                for (int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine($" {i + 1}: {Books[i].Title}");
                }
                Console.WriteLine();

                Console.Write("> ");

                string option = Console.ReadLine() ?? ""; //vraag optie

                try
                {
                    if (!int.TryParse(option, out int choicenOption))
                    {
                        if (option == "")//Als er  niets is ingevoerd

                            throw new ArgumentException("Kies een Optie");//als niet is ingevoerd

                        throw new FormatException("Ingvoerde waarde is een tekst");//Als een string is ingevoerd
                    }
                    else if (choicenOption > Books.Count + 1)//Als keuze buiten de aantal keuzens gaan
                    {
                        throw new IndexOutOfRangeException("Ingevoerde waarde staat is er niet!");
                    }

                    chosenBook = choicenOption;//als ingevoerde waarde een int is
                    chooseBook = false;//we verlaten dan de loop met books
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Druk op Enter >");
                    
                    Console.ReadLine();
                }
            } while (chooseBook);//als boek gekozen is stoppen we de loop
                                 //--------------------- einde, Boek kiezen ------------------------------//

            if (chosenBook == 0)//optie 0 is terug gaan
            {
                return;//terug keren naar BookMenu
            }
            else
            {
                if (!Books[chosenBook - 1].IsAvailable)
                {
                    TimeSpan daysBorrowed = DateTime.Now - Books[chosenBook - 1].BorrowingDate;
                    throw new ArgumentException($"Boek is al uitgeleend {Books[chosenBook - 1].BorrowingDate.ToString()}\nAantal dagen uitgeleend: {Books[chosenBook - 1].BorrowDays}\nAantal dagen uitgeleend: {(int)daysBorrowed.TotalDays}");
                }

                Books[chosenBook - 1].IsAvailable = false;//zet beschikbaarheid op false
                Books[chosenBook - 1].BorrowingDate = DateTime.Now;//wet uitleen datum op vandaag

                DateTime returnDate = DateTime.Now.AddDays(Books[chosenBook - 1].BorrowDays);//datum van terug brengen

                Console.WriteLine($"Boek:{Books[chosenBook - 1].Title}\nDag dat boek terug ingeleverd moet worden{returnDate.ToString("d")}");
            }
        }

        internal void AddBook(Book book)
        {
            if (Books is not null)
            {
                foreach (var ex in Books)
                {
                    if (ex.Equals(book))
                        throw new DuplicateDataException("Boek is al toegvoegd", book, ex);
                }
            }

            books.Add(book);
        }

        private bool IsValidISBN(string isbn)
        {
            // Verwijder streepjes
            string cleanIsbn = isbn.Replace("-", "");
            // @"^\d{10}$"
            //
            //@ negeert escape van \\
            //^ begin van de string
            //\d cijfers van {0 - 9}
            //{10} {13}  moet tien keer voor komen (length)
            //
            if (Regex.IsMatch(cleanIsbn, @"^\d{10}$") || Regex.IsMatch(cleanIsbn, @"^\d{13}$"))
            {
                return true;
            }
            return false;
        }

        internal void DeleteBook()
        {
            if (Books.Count == 0)
                throw new ArgumentException("Er zijn nog geen boeken toegevoegd");

            bool deleteMenu = true;

            do
            {
                Console.Clear();

                //Alle books in this tonen
                for (int i = 0; i < this.Books.Count; i++)
                {
                    if (i == 0)
                    {
                        this.books.Insert(0, new Book(this, "Terug", " gaan"));

                        Console.WriteLine($"{i}: <- {this.Books[i].Title}{this.Books[i].Author}");
                    }
                    else
                    {
                        Console.WriteLine($" {i}: {this.Books[i].Title}");
                    }
                }

                Console.WriteLine();
                Console.Write("Maak een keuze >");

                string toBeDeleted = Console.ReadLine() ?? "";

                Console.Clear();

                if (!int.TryParse(toBeDeleted, out int deleteBook))
                {
                    if (toBeDeleted == "")
                    {
                        deleteBook = this.Books.Count + 1;
                    }
                }

                try
                {
                    switch (deleteBook)
                    {
                        //is een letter
                        case -1:
                            throw new FormatException("Ingevoerde waarde is tekst");
                        //Terug naam boek menu
                        case 0:
                            deleteMenu = false;
                            break;
                        //gekozen nummer is te vinden in de bib --> deze verwijderen uit bib
                        case > 0:
                            for (int i = 0; i < this.Books.Count; i++)
                            {
                                if (this.Books[i].Title == this.Books[deleteBook - 1].Title)
                                {
                                    Console.WriteLine($"{this.Books[i].Title} :Verwijderd");
                                    this.Books.Remove(this.Books[i]);
                                }
                                else
                                {
                                    throw new ArgumentException("Gekoze boek staat niet in de lijst");
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("Gekozen boek is verwijderd\nDruk op enter");
                            Console.Write(">");
                            Console.ReadKey();

                            break;
                        //Keuze staat niet in de lijst, ingevoerde waarde pestaat niet
                        default:
                            throw new IndexOutOfRangeException("Gekoze Boek staat niet tussen de lijst");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Druk op Enter");
                Console.ReadLine();
            } while (deleteMenu);
        }

        internal void FindBookAuthAndTitle()
        {
            if (Books.Count == 0)
                throw new ArgumentException("Er zijn nog geen boeken toegevoegd");

            bool auteurTitleMenu = true;
            string[] options = ["Terug", "titel", "auteur"];

            do
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i}: {options[i]}");
                }

                Console.WriteLine();
                Console.Write("> ");
                string isOption = Console.ReadLine() ?? "";
                try
                {
                    if (!int.TryParse(isOption, out int opt))
                    {
                        if (isOption == "")
                            throw new ArgumentException("Kies een Optie");
                        throw new FormatException("Ingevoerde waarde is een tekst");
                    }
                    else
                    {
                        if (opt > options.Length)
                        {
                            throw new IndexOutOfRangeException("Optie staat niet in de lijst");
                        }
                    }

                    switch (opt)
                    {
                        case 0:
                            auteurTitleMenu = false;
                            break;
                        //zoeken op title
                        case 1:
                            //print de lijst van het Library Object -> list<Books> -> Title
                            for (int i = 0; i < this.Books.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}: {this.Books[i].Title}");
                            }
                            Console.WriteLine();

                            Console.Write("> ");
                            int selectedBook = Convert.ToInt32(Console.ReadLine());

                            this.Books[selectedBook - 1].Overview();
                            auteurTitleMenu = false;

                            break;
                        //Zoek op auteur
                        case 2:

                            int countAuth = 0;
                            List<string> authors = new List<string>();

                            for (int i = 0; i < this.Books.Count; i++)
                            {
                                if (!(authors.Contains(this.Books[i].Author)))
                                {
                                    countAuth++;
                                    authors.Add(this.Books[i].Author);

                                    Console.WriteLine($"{countAuth}: {this.Books[i].Author}");
                                }
                            }
                            Console.WriteLine("Maak een keuze");
                            Console.Write("> ");
                            string auteurKeuze = Console.ReadLine();

                            Console.Clear();
                            bool isAAuthor = int.TryParse(auteurKeuze, out int authorNum);

                            if (!isAAuthor)
                            {
                                throw new Exception("Invoer is niet geldig");
                            }
                            else if (authorNum > authors.Count)
                            {
                                throw new Exception("Ingevoerd cijfer bestaat niet");
                            }

                            Console.Clear();
                            Console.WriteLine(this.Books[authorNum - 1].Author);
                            Console.WriteLine(String.Empty.PadRight(this.Books[authorNum - 1].Author.Length, '*'));

                            foreach (Book book in this.Books)
                            {
                                if (book.Author == authors[authorNum - 1])
                                {
                                    book.Overview();
                                }
                            }
                            Console.WriteLine();
                            auteurTitleMenu = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Druk op Enter");
                    Console.ReadKey();
                }
            } while (auteurTitleMenu);
        }

        public void InfoBookMenu()
        {
            if (this.Books.Count == 0)
                throw new IndexOutOfRangeException($"'{this.NameLibary}' bevat nog geen boeken");

            //--------- Do While, optie boe
            do
            {
                bool chooseBook = true;
                bool chosenBookMenu = true;
                int chosenBook = -1;
                //--------------------- Do While, Boek kiezen ------------------------------//
                do
                {
                    Console.Clear();//blad leeg

                    Console.WriteLine("0: Terug gaan");//toon extra optie

                    //Alle books in this tonen
                    for (int i = 0; i < this.Books.Count; i++)
                    {
                        Console.WriteLine($" {i + 1}: {this.Books[i].Title}");
                    }
                    Console.WriteLine();

                    Console.Write("> ");

                    string option = Console.ReadLine() ?? ""; //vraag optie

                    try
                    {
                        if (!int.TryParse(option, out int choicenOption))
                        {
                            if (option == "")//Als er  niets is ingevoerd
                            {
                                throw new ArgumentException("Kies een Optie");//als niet is ingevoerd
                            }
                            else if (choicenOption > Books.Count + 1)//Als keuze buiten de aantal keuzens gaan
                            {
                                throw new IndexOutOfRangeException("Ingevoerde waarde staat is er niet!");
                            }
                            throw new FormatException("Ingvoerde waarde is een tekst");//Als een string is ingevoerd
                        }

                        chosenBook = choicenOption;//als ingevoerde waarde een int is
                        chooseBook = false;//we verlaten dan de loop met books
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                } while (chooseBook);
                //--------------------- einde, Boek kiezen ------------------------------//

                if (chosenBook == 0)
                {
                    infoMenu = false;
                }
                else
                {
                    do
                    {
                        Console.Clear();
                        int infoChoice;

                        //GEKOZEN BOEK TONEN
                        Console.WriteLine(this.Books[chosenBook - 1].Title);
                        Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));

                        //-------------------------------------------- Gekozen boek Opties -----------------------------------------//
                        //Array van opties  voor extra info
                        string[] infoOptions = ["Boek Wisselen", "Taal", "Genre", "Aantal Bladeren", "Doelgroep", "Samenvatting", "ISBN"];
                        for (int i = 0; i < infoOptions.Length; i++)
                        {
                            Console.WriteLine($"{i}: {infoOptions[i]}");
                        }
                        Console.WriteLine();

                        Console.Write("> ");
                        string infoOption = Console.ReadLine() ?? "";
                        try
                        {
                            //Checken of invoer interger is
                            if (!int.TryParse(infoOption, out int chosenOption))
                            {
                                if (infoOption == "")
                                    throw new ArgumentException("Kies een Optie");
                                throw new FormatException("Ingevoerde waarde is tekst");
                            }
                            else
                            {
                                if (chosenOption > infoOptions.Length)
                                {
                                    throw new IndexOutOfRangeException("Ingevoerde waarde staat is er niet!");
                                }
                            }

                            switch (chosenOption)
                            {
                                //Boek keizen -> Do While ^ hier voor
                                case 0:
                                    infoMenu = true;
                                    chosenBookMenu = false;
                                    break;
                                //Taal
                                case 1:
                                    try
                                    {
                                        Console.Clear();

                                        Console.WriteLine(this.Books[chosenBook - 1].Title);
                                        Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));//-----

                                        Console.WriteLine("Voer taal in: ");

                                        Console.WriteLine();

                                        Console.Write("> ");
                                        this.Books[chosenBook - 1].Language = Console.ReadLine();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.Write("Druk Enter >");
                                        Console.ReadKey();
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

                                            Console.WriteLine(this.Books[chosenBook - 1].Title);
                                            Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));

                                            Console.WriteLine("Voer Genre in: ");

                                            Console.WriteLine();

                                            Console.Write("> ");

                                            try
                                            {
                                                this.Books[chosenBook - 1].Genre = Console.ReadLine();
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

                                    Console.WriteLine(this.Books[chosenBook - 1].Title);
                                    Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));//--------

                                    Console.WriteLine("Voer aantal bladzijdes in: ");

                                    Console.WriteLine();

                                    Console.Write("> ");
                                    try
                                    {
                                        string pagesCount = Console.ReadLine();
                                        if (!int.TryParse(pagesCount, out int pages))
                                        {
                                            if (pagesCount == "")
                                                throw new ArgumentException("Voer een aantal in!");
                                            throw new FormatException("Ingevoerde waarde is een tekst");
                                        }
                                        Books[chosenBook - 1].Pages = pages;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.Write("Druk Enter >");
                                        Console.ReadKey();
                                    }

                                    break;
                                //Traget_Group
                                case 4:
                                    Console.Clear();

                                    Console.WriteLine(this.Books[chosenBook - 1].Title);
                                    Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));//--------

                                    Console.WriteLine("Voer doelgroep in: ");

                                    Console.WriteLine();

                                    Console.Write("> ");
                                    try
                                    {
                                        this.Books[chosenBook - 1].Target_Group = Console.ReadLine();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.Write("Druk Enter >");
                                        Console.ReadKey();
                                    }
                                    break;
                                //Summary
                                case 5:
                                    Console.Clear();

                                    Console.WriteLine(this.Books[chosenBook - 1].Title);
                                    Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));//--------

                                    Console.WriteLine("Voer samenvatting in: ");

                                    Console.WriteLine();

                                    Console.Write("> ");

                                    try
                                    {
                                        Books[chosenBook - 1].Summary = Console.ReadLine() ?? "";
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.Write("Druk Enter >");
                                        Console.ReadKey();
                                    }
                                    break;
                                //ISBN
                                case 6:

                                    Console.Clear();

                                    Console.WriteLine(this.Books[chosenBook - 1].Title);
                                    Console.WriteLine(String.Empty.PadRight(this.Books[chosenBook - 1].Title.Length, '*'));//--------

                                    Console.WriteLine("Voer ISBN in: ");
                                    Console.WriteLine();

                                    Console.Write("> ");
                                    try
                                    {
                                        this.Books[chosenBook - 1].ISBN = Console.ReadLine();
                                        Console.WriteLine("ISBN nummer is toegvoegd!!");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.Write("Druk op enter>");
                                        Console.ReadKey();
                                    }

                                    break;
                            }
                        ;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Write("Druk op Enter > ");
                            Console.ReadKey();
                        }
                    } while (chosenBookMenu);
                }
            } while (infoMenu);
        }

        internal void FindBookWithISBN()
        {
            Console.WriteLine("Voer een ISBN nummer in");
            Console.Write(">");
            string isbn = Console.ReadLine();

            if (!IsValidISBN(isbn))
            {
                throw new Exception("Ingevoerde waarde is geen geldige ISBN");
            }

            foreach (Book book in Books)
            {
                if (book.ISBN == isbn)
                {
                    book.Overview();
                }
            }
        }

        internal void FindBookFromAuth()
        {
            int countAuth = 0;
            List<string> authors = new List<string>();

            for (int i = 0; i < this.Books.Count; i++)
            {
                if (!(authors.Contains(this.Books[i].Author)))
                {
                    countAuth++;
                    authors.Add(this.Books[i].Author);

                    Console.WriteLine($"{countAuth}: {this.Books[i].Author}");
                }
            }
            Console.WriteLine("Maak een keuze");
            Console.Write("> ");
            string auteurKeuze = Console.ReadLine();

            Console.Clear();
            bool isAAuthor = int.TryParse(auteurKeuze, out int authorNum);

            if (!isAAuthor)
            {
                throw new Exception("Invoer is niet geldig");
            }
            else if (authorNum > authors.Count)
            {
                throw new Exception("Ingevoerd cijfer bestaat niet");
            }

            Console.Clear();
            Console.WriteLine(this.Books[authorNum - 1].Author);
            Console.WriteLine(String.Empty.PadRight(this.Books[authorNum - 1].Author.Length, '*'));

            foreach (Book book in this.Books)
            {
                if (book.Author == authors[authorNum - 1])
                {
                    Console.WriteLine($"{book.Title}");
                }
            }
        }

        internal void FindBooksByPages()
        {
            Console.WriteLine("Voer de aantal paginas in:");
            Console.Write(">");
            string pages = Console.ReadLine();

            bool isNumber = int.TryParse(pages, out int result);

            if (!isNumber)
            {
                throw new Exception("Input is geen cijfer");
            }

            foreach (Book book in Books)
            {
                if (book.Pages <= result)
                {
                    Console.WriteLine($"{book.Title} aantal Paginas: {book.Pages}");
                }
            }
        }

        internal void CsvFileReader()
        {
            string[] book;
            string[,] books;
            try
            {
                string csvPath = Library.GetCsvPath("boekenlijst_geformatteerd.csv");

                if (!File.Exists(csvPath))
                {
                    Console.WriteLine("CSV bestand niet gevonden op verwachtte locatie:");
                    Console.WriteLine(csvPath);
                    Console.WriteLine();
                    Console.WriteLine("Zorg dat 'boekenlijst_geformatteerd.csv' in de folder 'csv' naast de .sln staat,");
                    Console.WriteLine("of voeg het bestand toe in de map en start het programma opnieuw.");
                    return;
                }

                var lines = File.ReadAllLines(csvPath);
                Console.WriteLine($"Gevonden: {csvPath} (totaal regels: {lines.Length})");

                books = new string[lines.Length, 8];

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
                Console.WriteLine(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string FindProjectRoot()
        {
            DirectoryInfo dir = new DirectoryInfo(AppContext.BaseDirectory);

            while (dir != null)
            {
                if (dir.GetFiles("*.sln").Any())
                    return dir.FullName;

                if (dir.GetDirectories("csv").Any())
                    return dir.FullName;

                dir = dir.Parent;
            }

            var cwd = new DirectoryInfo(Directory.GetCurrentDirectory());
            dir = cwd;

            while (dir != null)
            {
                if (dir.GetFiles("*.sln").Any() || dir.GetDirectories("csv").Any())
                    return dir.FullName;
                dir = dir.Parent;
            }

            throw new InvalidOperationException("Project root kon niet worden gevonden. Zorg dat de .sln of de map 'csv' in een bovenliggende map staat.");
        }

        public static string GetCsvPath(string fileName)
        {
            var projectRoot = FindProjectRoot();
            var csvDir = Path.Combine(projectRoot, "csv");

            return Path.Combine(csvDir, fileName);
        }

        //------------------------- kranten en magazines -------------------------------------

        public void KrantEnMagazineMenu()
        {
            do
            {
                Console.Clear();

                List<int> datumGetal;
                DateTime date;

                string title;
                string publisher;

                NewsPaper krant;
                Magazine magazine;

                Console.WriteLine("Keuze Menu:");

                for (int i = 0; i < optionsReadingItems.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {optionsReadingItems[i]}");
                }

                Console.WriteLine();
                Console.Write("> ");

                string readingChoice = Console.ReadLine() ?? "";

                try
                {
                    string datum = "";
                    if (!int.TryParse(readingChoice, out int readingOption))
                    {
                        if (readingChoice == "")
                            throw new ArgumentException("Kies een Option");
                        throw new FormatException("Ingevoerde waarde is een tekst");
                    }
                    else
                    {
                        if (readingOption > optionsReadingItems.Length)
                        {
                            throw new IndexOutOfRangeException("Optie staan niet in de lijst");
                        }
                    }

                    switch (readingOption)
                    {
                        //voeg krant toe
                        case 1:
                            DateTime dateValue = new();
                            Console.WriteLine("Wat is de naam an de krant");
                            Console.Write(">: ");
                            title = Console.ReadLine() ?? "";

                            Console.WriteLine("Wat is de uitgeverij van de krant?");
                            Console.Write("> ");
                            publisher = Console.ReadLine() ?? "";

                            Console.WriteLine("Wat is de datum van de krant maand/dag/jaar");
                            Console.Write("> ");
                            datum = Console.ReadLine() ?? "1997/10/27";

                            if (!DateTime.TryParseExact(datum, "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                                throw new FormatException("Ingevoerde waarde is niet in juist format!");

                            krant = new NewsPaper(title, publisher, dateValue);

                            this.AddNewaPaper(krant);

                            break;
                        //voeg magazine toe
                        case 2:

                            Console.WriteLine("Wat is de naam an de magazine");
                            Console.Write(">: ");
                            title = Console.ReadLine() ?? "";

                            Console.WriteLine("Wat is de uitgeverij van de magazine?");
                            Console.Write("> ");
                            publisher = Console.ReadLine() ?? "";

                            Console.WriteLine("Wat is de datum van de magazine maand/dag/jaar");
                            Console.Write("> ");
                            datum = Console.ReadLine() ?? "1997/10/27";

                            if (!DateTime.TryParseExact(datum, "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                                throw new FormatException("Ingevoerde waarde is niet in juist format!");

                            magazine = new Magazine(title, publisher, dateValue);

                            AddMagazine(magazine);

                            break;
                        //toon kranten
                        case 3:
                            Console.WriteLine("De kranten in de leeszaal:");
                            ShowAllNewsPapers();
                            break;
                        //toon magazine's
                        case 4:
                            Console.WriteLine("Alle maandbladen uit de leeszaal:");
                            ShowAllMagazine();
                            break;
                        //wat is er in de leesruimte
                        case 5:
                            Console.WriteLine($"Aanwinsten in de leeszaal van {DateTime.Now.ToString("D")}");
                            AcquisitionsReadingRoomToday();
                            Console.Write("> ");
                            Console.ReadKey();
                            break;

                        default:
                            readingRoomMenu = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Druk op Enter >");
                    Console.ReadKey();
                }
            } while (readingRoomMenu);
        }

        internal void AddNewaPaper(ReadingRoomItem item)
        {
            foreach (var ex in allReadingRoom.Values)
            {
                if (ex is NewsPaper && ex.Equals(item))
                    throw new DuplicateReadingRoomItemException("Krant is al aanwezig", item, ex);

            }
            DateTime addedDate = DateTime.Now;
            allReadingRoom.Add(addedDate, item);
        }

        internal void AddMagazine(ReadingRoomItem item)
        {
            foreach(var ex in allReadingRoom.Values)
            {
                if (ex is Magazine && ex.Equals(item))
                    throw new DuplicateReadingRoomItemException("Magazine is al aanwezig", item, ex);

            }
            DateTime addedDate = DateTime.Now;
            allReadingRoom.Add(addedDate, item);
        }

        internal void ShowAllNewsPapers()
        {
            if (allReadingRoom.Count == 0)
            {
                throw new ArgumentException("Er is nog niets toegevoegd");//wanneer er nog niets is sowel geen kranten als magazines
            }
            else
            {
                bool existingKrant = false;
                foreach (var item in allReadingRoom)
                {
                    if (item.Value.GetType().Name == "NewsPaper")//als er wel kranten zijn
                    {
                        existingKrant = true;
                        Console.WriteLine(item.Value.Title);
                    }
                }

                if (!existingKrant)//als er wel magazines zijn maar geen kranten
                    throw new ArgumentException("Er zijn nog geen kranten toegevoegd");
            }

            Console.Write("Druk Op Enter >");
            Console.ReadKey();
        }

        internal void ShowAllMagazine()
        {
            if (allReadingRoom.Count == 0)
            {
                throw new ArgumentException("Er is nog niets toegevoegd");//wanneer er nog niets is sowel geen kranten als magazines
            }
            else
            {
                bool existingMagazine = false;
                foreach (var item in allReadingRoom)
                {
                    if (item.Value.GetType().Name == "Magazine")//als er wel kranten zijn
                    {
                        existingMagazine = true;
                        Console.WriteLine(item.Value.Title);
                    }
                }

                if (!existingMagazine)//als er wel magazines zijn maar geen kranten
                    throw new ArgumentException("Er zijn nog geen magazine toegevoegd");
            }

            Console.Write("Druk Op Enter >");
            Console.ReadKey();
        }

        internal void AcquisitionsReadingRoomToday()
        {
            if (allReadingRoom is not null)
            {
                foreach (var item in allReadingRoom)
                {
                    var id = item.Value.Identification;
                    var title = item.Value.Title;

                    Console.WriteLine($"{title} met id {id}");
                }
            }
        }
    }
}