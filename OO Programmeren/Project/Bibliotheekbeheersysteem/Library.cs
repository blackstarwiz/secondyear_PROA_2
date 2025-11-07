using System.Text.RegularExpressions;

namespace Bibliotheekbeheersysteem
{
    internal class Library
    {
        private string nameLibary;
        private List<Book> books = new List<Book>();
        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();

        public Library(string name)
        {
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

        internal void AddBook(Book book)
        {
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
            Console.Clear();
            int deleteBook = -1;

            //Alle books in bib tonen
            for (int i = 0; i < this.Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {this.Books[i].Title}");
            }

            Console.WriteLine();
            Console.WriteLine("Maak een keuze:");
            Console.Write("> ");

            string toBeDeleted = Console.ReadLine();

            Console.Clear();
            //Checken of input een nummer is of niet
            bool isNumber = int.TryParse(toBeDeleted, out int isBook);

            //We kijken na of ingevoerde nummer niet groter is dan de aantal boeken in de bib
            if (!isNumber)
            {
                deleteBook = -1;
            }
            else
            {
                if (!(isBook > this.Books.Count))
                {
                    deleteBook = isBook;
                }
                else
                {
                    deleteBook = 0;
                }
            }

            switch (deleteBook)
            {
                //is een letter
                case -1:
                    throw new Exception("Geen geldige waarde, voer een cijfer in!");
                    break;
                //gekozen boek bestaat niet
                case 0:
                    throw new Exception($"Gekozen boek is niet in bib te vinden\nVoer een geldig nummer in");
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
            }
        }

        internal void FindBookAuthAndTitle()
        {
            bool auteurTitleMenu = true;
            string[] optie = ["titel", "auteur"];
            int keuzeZoeken;

            do
            {
                Console.Clear();
                for (int i = 0; i < optie.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {optie[i]}");
                }

                Console.WriteLine();
                Console.Write("> ");
                string isOptie = Console.ReadLine();

                Console.Clear();
                bool checkIsNumber = int.TryParse(isOptie, out int numberOptie);

                if (checkIsNumber && numberOptie <= optie.Length)
                {
                    keuzeZoeken = numberOptie;
                }
                else
                {
                    keuzeZoeken = 0;
                }

                switch (keuzeZoeken)
                {
                    case 0:
                        throw new Exception("Invoer niet geldig!");
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
            } while (auteurTitleMenu);
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

        internal void AddNewaPaper(ReadingRoomItem item)
        {
            DateTime addedDate = DateTime.Now;
            allReadingRoom.Add(addedDate, item);
        }

        internal void AddMagazine(ReadingRoomItem item)
        {
            DateTime addedDate = DateTime.Now;
            allReadingRoom.Add(addedDate, item);
        }

        internal void ShowAllNewsPapers()
        {
            foreach (var krant in allReadingRoom)
            {
                if (krant.Value.GetType().Name == "NewsPaper")
                {
                    Console.WriteLine(krant.Value.Publisher);
                }
            }
        }

        internal void ShowAllMagazine()
        {
            foreach (var magazine in allReadingRoom)
            {
                if (magazine.Value.GetType().Name == "Magazine")
                {
                    Console.WriteLine(magazine.Value.Publisher);
                }
            }
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