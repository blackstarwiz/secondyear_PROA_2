using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Alumnus : Person
    {

        //list alulumni
        private static ImmutableList<Alumnus> allAllumni = ImmutableList<Alumnus>.Empty;

        //constructor alumnus
        public Alumnus(string name, DateTime birthDate, int graduationYear) : base(name,birthDate) {
            allAllumni.Add(this);
            GraduationYear = graduationYear;
        }


        //propertys
        private CareerInfo career;

        public CareerInfo Career
        {
            get
            {
                return career;
            }
        }

        private int graduationYear;
        public int GraduationYear
        {
            get
            {
                return graduationYear;
            }
            set
            {
                graduationYear = value;
            }
        }

        public bool IsEmployed
        {
            get
            {
                if (Career != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public static ImmutableList<Alumnus> AllAllumni
        {
            get
            {
                return allAllumni.ToImmutableList<Alumnus>();
            }
        }

        //methode's
        public void UpdateCarreer(string company, string position, WorkType workType, int years)
        {
            CareerInfo newCareer = new CareerInfo(company,position,workType,years);
        }

        public override string GenerateNameCard()
        {
            return $"Alumnus: {Name}, afgestudeeerd {GraduationYear}";
        }

        public override double DetermineWorkload()
        {
            return 0;
        }

        public override string ToString()
        {
            string output = "";
           
            string nameCard = GenerateNameCard();

            string career = "";

            if(!IsEmployed)
            {
                career = "Nog geen werkervaring geregistreerd";
            }
            else
            {
                career = Career.ToString();
            }

            output = $"{nameCard}\n{career}";

            return career;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (!(obj is Alumnus))
            {
                return false;
            }
            else
            {
                return ((Person)obj).Name == this.Name;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
