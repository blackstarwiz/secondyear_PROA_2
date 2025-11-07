namespace Bibliotheekbeheersysteem
{
    internal class NewsPaper : ReadingRoomItem
    {
        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher, date)
        {
        }

        public override string Identification
        {
            get
            {
                string intials;
                string date;

                if (Title.Contains(' '))
                {
                    string[] words = Title.Split(" ");
                    intials = "";

                    foreach (string word in words)
                    {
                        intials += word.Substring(0, 1);
                    }

                    date = date = $"{base.Date.Day}{base.Date.Month}{base.Date.Year}";
                }
                else
                {
                    intials = Title.Substring(0, 1);
                    date = date = $"{base.Date.Day}{base.Date.Month}{base.Date.Year}";
                }

                return $"{intials}{date}";
            }
        }

        public override string Categorie => "Krant";
    }
}