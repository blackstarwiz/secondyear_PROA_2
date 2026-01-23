using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class InternShipLecturer : Lecturer, IIntershipable
    {
        private TimeSpan hours;
        private string company;//niet nodig?? we geven voor de lector altijd AP terug
        private List<Student> internStudents;

        public InternShipLecturer(string name, DateTime birthdate, Dictionary<string, byte> courses) : base(name, birthdate, courses)
        {
            internStudents = new List<Student>();//lege lijst
        }

        public TimeSpan Hours
        {
            get
            {
                if (internStudents.Count == 0)
                    throw new ArgumentNullException("Er zijn nog geen studenten toegvoegd");
                int uren = 25 * internStudents.Count;//we gaan altijd 25 * aantalstudenten doen om de uren te bepalen
                hours = new TimeSpan(0, uren, 0);
                return hours;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                throw new TyringToLeaveAPException(Name);
            }
        }

        /*public string CompanyName
        {
            get
            {
                return "AP";
            }
            set
            {
            }
        }*/

        public void PrintInternshipInfo()
        {
            if (internStudents.Count == 0)
                throw new ArgumentNullException("Er zijn nog geen studenten toegevoegd");

            //sorteren van studenten op naam
            internStudents.Sort(new StudentsAscendingByName());

            //tonen van de naam van de lector in bepaald formaat
            string intro = "Intership";
            Console.WriteLine(intro);
            Console.WriteLine(string.Empty.PadLeft(intro.Length, '*'));

            Console.WriteLine($"{Name} begleidt");
            //PrintInfo Van elke student aanspreken en afprinten
            foreach(var student in internStudents)
            {
                student.PrintInternshipInfo();
            }

            //workload
            Console.WriteLine($"Workload:{Math.Round(DetermineWorkload())}");
        }

        public void AddStudent(Student student)
        {
            //toevoegen van de student een internStudents

            internStudents.Add(student);
        }

        public override double DetermineWorkload()
        {
            return AllCourses.Values.Sum(v => (double)v) + Hours.TotalHours;
        }

        public static void Demo()
        {
            //Person students;
            InternShipLecturer lector;
            //Studenten aanmaken

            var student1 = new Student("Sara", new DateTime(2006,02,13),"Aller beste bedrijf ooit");
            var student2 = new Student("Isaak", new DateTime(2005,03,10),"Beste bedrijf ooit");
            //loctor aanmaken
            lector = new InternShipLecturer("Bart", new DateTime(1995,09,09), null);
            //studenten toevoegen aan de list
            lector.AddStudent(student1);
            lector.AddStudent(student2);

            //print info van lector
            lector.PrintInternshipInfo();
            //print workload van de lector
            lector.DetermineWorkload();


            //sorteren met leeftijd
            var admin = new AdministrativePersonnel("Zaid", new DateTime(2007, 01, 01), null);

            var lijstPersonen = Person.AllPersons;

            lijstPersonen.Add(null);

            Console.WriteLine("Druk op Enter");
            Console.Write("> ");
            Console.ReadKey();
        }
    }
}