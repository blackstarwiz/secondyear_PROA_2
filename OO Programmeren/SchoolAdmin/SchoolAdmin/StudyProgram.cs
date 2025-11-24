using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudyProgram
    {
        private string name;

        //private readonly ImmutableList<Course> courses = ImmutableList<Course>.Empty;
        //private byte semester;
        private readonly Dictionary<Course, byte> courses;

        public StudyProgram(string name, Dictionary<Course, byte> courses)
        {
            this.Name = name;
            this.courses = courses;
        }

        public StudyProgram(string name) : this(name, null)
        {
        }

        public ImmutableDictionary<Course, byte> Courses
        {
            get
            {
                return courses.ToImmutableDictionary();
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

        public void ShowOverview()
        {
            Console.WriteLine($"Programma: {this.Name}");
            //Console.WriteLine(String.Empty.PadLeft(this.Name.Length, '*'));
            Console.WriteLine();

            //voor 3 semesters
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Semester {i + 1}:");

                bool hasCourses = false;
                //bekijken we de courses
                foreach (var kv in Courses)
                {
                    //als de kv.Value (Semester) is gelijk aan het semester
                    if (kv.Value == i+1)
                    {
                        hasCourses = true ;

                        //print key (course.title + course.creditpoints)
                        Course course = kv.Key;
                        Console.WriteLine($"{course.Title}\t({course.CreditPoints}sp)");
                    }
                    //als er geen zijn zou er een tekst moeten zijn "Er zijn geen cursussen in semester {i+!}"
                }

                if (!hasCourses)
                {
                    Console.WriteLine($"Er zijn geen cursussen in semester {i+1}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void Remove(string input)
        {
            foreach (var k in Courses.Keys)
            {
                if (k.Title != input)
                {
                    throw new Exception("Ingevoerde richting is er niet");
                }
                Courses.Remove(k);
            }
        }
    }
}