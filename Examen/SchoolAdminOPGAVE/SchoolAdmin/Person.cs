using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public abstract class Person: ICSVSerializable
    {
        private uint id;
        public uint Id
        {
            get { return id; }
        }
        private static uint maxId = 1;

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
        }
        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int numberOfYears = now.Year - this.BirthDate.Year;
                if (now.Month < this.BirthDate.Month || now.Month == this.BirthDate.Month && now.Day < this.BirthDate.Day)
                {
                    numberOfYears--;
                }
                return numberOfYears;
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private static List<Person> allPersons = new List<Person>();
        public static ImmutableList<Person> AllPersons
        {
            get { return allPersons.ToImmutableList<Person>(); }
        }


        public Person(string name, DateTime birthDate)
        {
            this.id = maxId;
            maxId++;
            this.Name = name;
            this.birthDate = birthDate;
            allPersons.Add(this);
        }
        public abstract double DetermineWorkload();
        public abstract string GenerateNameCard();

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (!(obj is Person))
            {
                return false;
            }
            else
            {
                return ((Person)obj).Id == this.Id;
            }
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public override string ToString()
        {
            string tekst = "";
            tekst += "Persoon\n";
            tekst += "-------\n";
            tekst += $"Naam: {this.Name}\n";
            tekst += $"Leeftijd: {Age}";
            return tekst;
        }

        public virtual string ToCSV()
        {
            return $"{this.Id};{this.Name};{this.BirthDate.ToString("d")}";
        }

    }
}
