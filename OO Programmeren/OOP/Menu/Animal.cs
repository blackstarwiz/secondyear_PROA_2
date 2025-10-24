using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public abstract class Animal
    {
        public enum Genders
        {
            Male,
            Female
        }
        private string name;

        private Genders gender;

        //private ImmutableList<string> allergies = ImmutableList<string>.Empty;
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

        public Genders Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public abstract ImmutableList<string> Allergies
        {
            get;
            set;
        }

        public abstract void ShowChip();
        
        public static void DemoVet()
        {
            var patients = new List<Animal>();
            var animal1 = new Dog();
            animal1.IndividualAllergies = new List<string> { "vis" };
            animal1.Chip = "ABC123";
            animal1.Gender = Genders.Female;
            animal1.Name = "Misty";
            patients.Add(animal1);
            var animal2 = new Parrot();
            animal2.Gender = Genders.Male;
            animal2.Name = "Coco";
            patients.Add(animal2);
            foreach (var animal in patients)
            {
                Console.WriteLine(animal.Name);
                Console.WriteLine(animal.Gender);
                Console.WriteLine("allergieën:");
                foreach (var allergie in animal.Allergies)
                {
                    Console.WriteLine(allergie);
                }
                animal.ShowChip();
            }
        }
    }

    public class Dog : Animal
    {
        private List<string> individualAllergies;
        private string chip;

        public List<string> IndividualAllergies
        {
            get
            {
                return individualAllergies;
            }
            set
            {
                individualAllergies = value;
            }
        }

        public override ImmutableList<string> Allergies
        {
            get
            {
                //We gaan kijken of de list iets bevat anders maken we een lege list to we
                //omzetten naar ImmutableList()
                return (IndividualAllergies ?? new List<string>()).ToImmutableList();
            }
            set
            {
                //we gaan of te wel de value list meegeven anders als deze niet bestaat maken we er 1
                //met immutable -> mutable (.ToList())
                IndividualAllergies = (value ?? ImmutableList<string>.Empty).ToList();
            }
        }

        public string Chip
        {
            get
            {
                return chip;
            }
            set
            {
                chip = value;
            }
        }

        public override void ShowChip()
        {
            Console.WriteLine(chip);
        }
    }

    public class Parrot : Animal
    {
        private List<string> individualAllergies;
        private string chip;

        public List<string> IndividualAllergies
        {
            get
            {
                return individualAllergies;
            }
            set
            {
                individualAllergies = value;
            }
        }

        public override ImmutableList<string> Allergies
        {
            get
            {
                //We gaan kijken of de list iets bevat anders maken we een lege list to we
                //omzetten naar ImmutableList()
                return (IndividualAllergies ?? new List<string>()).ToImmutableList();
            }
            set
            {
                //we gaan of te wel de value list meegeven anders als deze niet bestaat maken we er 1
                //met immutable -> mutable (.ToList())
                IndividualAllergies = (value ?? ImmutableList<string>.Empty).ToList();
            }
        }

        public string Chip
        {
            get
            {
                return chip;
            }
            set
            {
                chip = value;
            }
        }

        public override void ShowChip()
        {
            Console.WriteLine(chip);
        }
    }

}
