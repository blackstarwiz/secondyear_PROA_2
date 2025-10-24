using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal abstract class Person
    {
        private uint id;
        private static uint maxId = 1;
        private string name;
        private DateTime birthDate;
        private static ImmutableList<Person> allPersons = ImmutableList<Person>.Empty;
        
        public Person(string name, DateTime birthdate)
        {
            id = maxId;
            maxId++;

            Name = name;

            birthDate = birthdate;

            allPersons =  allPersons.Add(this);
        }
        public uint Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
            set
            {
                allPersons = value;
            }
        }

        public abstract string GenerateNameCard();

        public abstract double DetermineWorkload();
    }
}
