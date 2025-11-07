using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student : Person
    {

        private List<CourseRegistration> courseRegistrations = new List<CourseRegistration>();


        private static List<Student> allStudents = new List<Student>();
        public static ImmutableList<Student> AllStudents
        {
            get { return allStudents.ToImmutableList<Student>(); }
        }

        private Dictionary<DateTime, string> studentFile = new Dictionary<DateTime, string>();
        public ImmutableDictionary<DateTime, string> StudentFile
        {
            get { return studentFile.ToImmutableDictionary<DateTime, string>(); }
        }


        public Student(string name, DateTime birthDate) : base(name, birthDate)
        {
            allStudents.Add(this);
        }

        public override string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public override double DetermineWorkload()
        {
            double total = 0;
            foreach (CourseRegistration course in courseRegistrations)
            {
                if (course is not null)
                {
                    total += 10;
                }
            }
            return total;
        }

        public void RegisterCourseResult(Course course, byte? result)
        {
            if (result > 20)
            {
                Console.WriteLine("Ongeldig cijfer!");
            }
            else
            {
                CourseRegistration newCourseresult = new CourseRegistration(course, result);
                courseRegistrations.Add(newCourseresult);
            }
        }
        public double Average()
        {
            double totaal = 0;
            int counter = 0;
            foreach (CourseRegistration item in courseRegistrations)
            {
                if (!(item.Result is null))
                {
                    totaal += (byte)item.Result;
                    counter++;
                }
            }
            return totaal / counter;
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{this.Name} ({Age} jaar)");
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()} uren");
            Console.WriteLine("Cijferrapport");
            Console.WriteLine("*************");
            foreach (CourseRegistration item in courseRegistrations)
            {
                Console.WriteLine($"{item.Course.Title}:\t{item.Result}");
            }
            Console.WriteLine($"Gemiddelde:\t{this.Average():F1}\n");
        }

        public override string ToString()
        {
            return base.ToString() + "\nStudent";
        }


    }
}
