using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheekbeheersysteem
{
    internal class Magazine : ReadingRoomItem
    {
        public Magazine(string title, string publisher, DateTime date) : base(title, publisher, date)
        {
        }

        public override string Identification
        {
            get
            {
                string intials;
                string date;
                if (Title.Contains(" "))
                {
                    string[] words = Title.Split(" ");
                    intials = "";

                    foreach (string word in words)
                    {
                        intials += word.Substring(0, 1);
                    }

                    date = $"{base.Date.Month}{base.Date.Year}";
                }
                else
                {
                    intials = Title.Substring(0, 1);
                    date = $"{base.Date.Month}{base.Date.Year}";
                }

                return $"{intials}{date}";
            }
        }

        public override string Categorie => "MaandBlad";
    }
}