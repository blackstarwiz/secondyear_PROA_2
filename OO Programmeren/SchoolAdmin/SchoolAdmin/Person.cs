using System.Collections.Immutable;

namespace SchoolAdmin
{
    public abstract class Person : IComparable<Person>
    {
        private uint id;
        private static uint maxId = 1;
        private string? name = null;
        private DateTime birthDate;
        private static ImmutableList<Person> allPersons = ImmutableList<Person>.Empty;

        public Person(string name, DateTime birthdate)
        {
            id = maxId++;

            this.name = name;

            birthDate = birthdate;
            allPersons = allPersons.Add(this);
        }

        public Person()
        {
        }

        public uint Id
        {
            get
            {
                return id;
            }
        }

        public string? Name
        {
            get
            {
                return name;
            }
        }

        private DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
        }

        public int Age
        {
            get
            {
                TimeSpan age = DateTime.Now - BirthDate;
                return age.Days / 365;
            }
        }

        public static ImmutableList<Person> AllPersons
        {
            get
            {
                return allPersons.ToImmutableList();
            }
        }

        public int CompareTo(Person? other)
        {
            if (this == null && other == null)
                return 0;
            if (this == null)
                return -1; //A

            if (other == null)//tot
                return 1;//Z

            if (this.Name is null)
                return 0;

            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is null))
                return obj is Person other && Id == other.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public abstract string GenerateNameCard();

        public abstract double DetermineWorkload();

        public override string ToString()
        {
            string person = "Person\n";
            string underline = $"{String.Empty.PadRight(person.Length, '-')}\n";
            string name = $"Name {GenerateNameCard()}\n";
            string age = $"Leeftijd: {Age}\n";

            return $"{person}{underline}{name}{age}";
        }
    }
}