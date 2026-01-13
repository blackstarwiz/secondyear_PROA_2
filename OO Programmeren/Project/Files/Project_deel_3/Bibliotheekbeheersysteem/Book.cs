using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bibliotheekbeheersysteem 
{
    //EINGENSCHAPPEN BOEK
    /*
        1.title,
        2.auteur,
        3.taal,
        4.ISBN,
        5.genre,
        6.aantal bladeren,
        7.doelgroep,
        8.samenvatting (kort/lang),
      */

    internal enum Genres
    {
        Actie = 1,
        Avontuur,
        Biografie,
        Kinder,
        Klassieke_fictie,
        Misdaad,
        Mysterie,
        Fantasie,
        Horror,
        Humor,
        Wetenschap
    }

    internal class Book : ILendable
    {
        
        private string title;
        private string author;
        private string language;
        private string isbn;
        private Genres genre;
        private int pages;
        private string target_group;
        private string summary;

        public Book(Library library, string title, string author)
        {
            
            if (title == "Terug")
            {
                this.Title = title;
                this.Author = author;
            }
            else
            {
                IsAvailable = true;


                this.Title = title;
                this.Author = author;
                library.AddBook(this);
            }
        }


       
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Veld is leeg, voer geldige titel in!");
                }
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Veld is leeg, voer geldige auteur in!");
                }
                author = value;
            }
        }

        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Veld is leeg, voer geldige taal in!");
                }
                language = value;
            }
        }

        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                if (IsValidISBN(value))
                {
                    isbn = value;
                }
                else
                {
                    throw new ArgumentException("Ongeldig ISBN formaat.");
                }
            }
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

        public string Genre
        {
            get
            {
                return genre.ToString();
            }
            set
            {
                //eerste letter naar Upper, rest naar Lower
                string firstLetter = value.Substring(0, 1).ToUpper();
                string rest = value.Substring(1).ToLower();
                string resultGenre = firstLetter + rest;

                //Verplaats legen ruimste " " met "_"
                resultGenre = resultGenre.Replace(" ", "_");

                Genres genre;
                if (!Enum.TryParse(resultGenre, out genre) || !Enum.IsDefined(typeof(Genres), genre))
                {
                    throw new Exception($"Genre bestaat niet!");
                }
                Console.WriteLine("Genre is Toegevoegd!!");
                this.genre = genre;
            }
        }

        public List<Genres> Genres
        {
            get
            {
                return Enum.GetValues(typeof(Genres)).Cast<Genres>().ToList();
            }
        }

        public int Pages
        {
            get
            {
                return pages;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Veld is leeg, voer aantal paginas in!");
                }
                pages = value;
            }
        }

        public string Target_Group
        {
            get
            {
                return target_group;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Veld is leeg, voer geldige doelgroep in!");
                }
                target_group = value;
            }
        }

        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                if (int.TryParse(value, out int integer))
                {
                    throw new FormatException("Ingevoerde waarde is enkel een getal");
                }

                if (value == "")
                    throw new Exception("Veld is leeg, voer geldige samenvatting in!");

                summary = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Book other && obj.Equals(other.Title);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title);
        }



        //-----------------------ILenable------------------------


        private bool isAvailable;
        private DateTime borrowingDate;
        private int borrowDays;

        public DateTime BorrowingDate
        {
            get
            {
               
                return borrowingDate;
            }
            set
            {
                borrowingDate = value;
            }
        }
         public int BorrowDays
        {
            get
            {
                TimeSpan days;

                if (this.Genre == "Schoolbook")
                {
                    days = BorrowingDate.AddDays(10) - BorrowingDate;
                }
                else
                {
                    days = BorrowingDate.AddDays(20) - BorrowingDate;
                }
                return (int)days.TotalDays;
            }
            set
            {
                borrowDays = value;
            }
        }
        
        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
            }
        }



        public void Borrow()
        {
            
        }

        public void Return()
        {

        }
        //-----------------einde ILenable -------------------------
        public void Overview()
        {
            string bookOverview = $"titel: {Title}\n auteur: {Author}\n genre: {Genre}\n isbn: {ISBN}\n taal: {Language}\n aantal paginas: {Pages}\n doelgroep: {Target_Group}\n samenvatting: {Summary}";

            Console.WriteLine(bookOverview);
        }
    }
}