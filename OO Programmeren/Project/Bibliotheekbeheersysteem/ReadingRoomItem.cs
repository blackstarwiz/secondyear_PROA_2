using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheekbeheersysteem
{
    internal abstract class ReadingRoomItem
    {
        private string title;
        private string publisher;
        private DateTime date;


        public ReadingRoomItem(string title,string publisher, DateTime date)
        {
            Title = title;
            Publisher = publisher;

            try
            {
                int year = date.Year;
                int month = date.Month;


                // als maand tussen 1 en 12
                if(month > 0 && month <= 12)
                {
                    //als year niet groter is dan 2500
                    if(year <= 2500)
                    {
                        this.date = date;
                    }
                    //als year groter is dan 2500
                    else
                    {
                        throw new ArgumentException("Het jaartal is maximaal 2500");
                    }
                }
                // als maand is groter 12 of kleiner 1 is 
                else
                {
                    //als year groter is dan 2500
                    if (year > 2500)
                    {
                        throw new ArgumentException("Maand is niet tussen 1 en 12\nHet jaartal is maximaal 2500");

                    }

                    throw new ArgumentException("Maand is niet tussen 1 en 12");
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public DateTime Date
        {
            get
            {
                return date;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }private set
            {
                if (!int.TryParse(value, out int result))
                {
                    if(value == "")
                        throw new ArgumentException("Er is niets ingevoerd bij naam");
                    title = value;
                }
                else
                {
                    throw new ArgumentException("Voer een naam in aub!");
                }
               
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }
            private set
            {
                if (!int.TryParse(value, out int result))
                {
                    if (value == "")
                        throw new ArgumentException("Er is niets ingevoerd bij uitgever");
                    publisher = value;
                }
                else
                {
                    throw new ArgumentException("Voer een uitgever in aub!");
                }
               
            }
        }

        public abstract string Identification
        {
            get;
        }

        public abstract string Categorie
        {
            get;
        }

        public override bool Equals(object? obj)
        {

            return obj is ReadingRoomItem other && this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title,Date.Year);
        }
    }
}
