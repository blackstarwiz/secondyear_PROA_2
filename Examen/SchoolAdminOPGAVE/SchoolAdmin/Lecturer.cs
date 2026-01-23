using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class Lecturer:Employee
    {
        public Dictionary<Course, double> Courses = new Dictionary<Course, double>();

        public static ImmutableList<Lecturer> AllLecturers
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<Lecturer>();
                foreach (Person pers in Person.AllPersons)
                {
                    if (pers is Lecturer)
                    {
                        builder.Add((Lecturer)pers);
                    }
                }
                return builder.ToImmutableList<Lecturer>();

            }
        }
        public Lecturer(string name, DateTime birthDate, Dictionary<string, byte> tasks) : base(name, birthDate, tasks)
        {
        }
        public override double DetermineWorkload()
        {
            double total = 0;
            foreach (var item in Courses)
            {
                total += item.Value;
            }
            return total;
        }
        public override uint CalculateSalary()
        {
            double baseSalary = 2200 + (Seniority / 4 * 120);
            double fraction = DetermineWorkload() / 40;
            return (uint)(baseSalary * fraction);
        }
        public override string GenerateNameCard()
        {
            string infoLecturer = this.Name;
            infoLecturer += "\nLector voor:";
            foreach (Course course in Courses.Keys)
            {
                infoLecturer += "\n" + course.Title;
            }
            return infoLecturer;
        }
        public override string ToString()
        {
            return base.ToString() + "\nLector";
        }

        public override string ToCSV()
        {
            string courseInfo = "";
            foreach (var course in Courses)
            {
                courseInfo += $";{course.Key.Title};{course.Value}";

            }
            return "Lector;" + base.ToCSV() +courseInfo;
        }


    }
}
