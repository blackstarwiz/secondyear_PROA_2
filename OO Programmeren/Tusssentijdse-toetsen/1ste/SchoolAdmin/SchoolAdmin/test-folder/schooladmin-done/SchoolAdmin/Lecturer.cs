using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Lecturer:Employee
    {
        public Dictionary<Course, double> Courses = new Dictionary<Course, double>();
        private static List<Lecturer> allLecturers = new List<Lecturer>();
        private List<Alumnus> guideAlumni = new List<Alumnus>();

        public List<Alumnus> GuidedAlumni
        {
            get
            {
                return guideAlumni;
            }
            set
            {
                guideAlumni = value;
            }
        }


        public static ImmutableList<Lecturer> AllLecturers
        {
            get
            {
                return allLecturers.ToImmutableList<Lecturer>();
            }
        }
        public Lecturer(string name, DateTime birthDate, Dictionary<string, byte> tasks) : base(name, birthDate, tasks)
        {
            allLecturers.Add(this);
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
            double basis = 2200 + (Seniority / 4 * 120);
            double breuk = DetermineWorkload() / 40;
            return (uint)(basis * breuk);
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

        public void AddAlumnus(Alumnus alumnus)
        {

            if(GuidedAlumni is null)
            {
                GuidedAlumni.Add(alumnus);
                Console.WriteLine($"Lector {this.Name} heeft alumnus {alumnus.Name} begleid (afgestudeerd in {alumnus.GraduationYear})");
            }
            else
            {
                if (GuidedAlumni.Equals(alumnus))
                {
                    Console.WriteLine($"Alumnus {alumnus.Name} is al gekoppeld aand lector {this.Name}");
                }
                else
                {
                    GuidedAlumni.Add(alumnus);

                    Console.WriteLine($"Lector {this.Name} heeft alumnus {alumnus.Name} begleid (afgestudeerd in {alumnus.GraduationYear})");
                }
            }
            
        }
    }
}
