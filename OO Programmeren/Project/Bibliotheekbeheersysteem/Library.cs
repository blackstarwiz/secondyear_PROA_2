namespace Bibliotheekbeheersysteem
{
    internal class Library
    {
        private string nameLibary;
        private List<Book> books = new List<Book>();

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

        internal void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}