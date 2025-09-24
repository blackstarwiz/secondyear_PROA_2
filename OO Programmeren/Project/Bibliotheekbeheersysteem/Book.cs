using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    internal class Book
    {
        private string title;
        private string author;
        private string language;
        private int isbn;
        private string genre;
        private int pages;
        private string target_group;
        private string summary;

        public Book(Library library, string title, string author)
        {
            this.Title = title;
            this.Author = author;

            library.AddBook(this);
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

        public int ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                //voor de set moet er eerst gecheck worden op bepaalde voorwaardes
                isbn = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("Veld is leeg, voer geldige genre in!");
                }
                genre = value;
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
                if (value == "")
                {
                    throw new Exception("Veld is leeg, voer geldige samenvatting in!");
                }
                summary = value;
            }
        }

        public void Overview()
        {
            string bookOverview = $"titel: {Title}\n auteur: {Author}\n genre: {Genre}\n isbn: {ISBN}\n taal: {Language}\n aantal paginas: {Pages}\n doelgroep: {Target_Group}\n samenvatting: {Summary}";

            Console.WriteLine(bookOverview);
        }
    }
}