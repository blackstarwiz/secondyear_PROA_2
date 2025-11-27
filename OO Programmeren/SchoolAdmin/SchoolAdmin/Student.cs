using System.Collections.Immutable;
using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student : Person
    {
        //private List<CourseRegistration> courseRegistrations = new List<CourseRegistration>();
        //private static readonly ImmutableList<Student>.Builder allStudents = ImmutableList.CreateBuilder<Student>();
        private ImmutableDictionary<DateTime, string> studentFile = ImmutableDictionary<DateTime, string>.Empty;

        public Student(string name, DateTime birthdate) : base(name, birthdate)
        {
            // allStudents.Add(this);
        }

        public Student Allstudents
        {
            get
            {
                return this;
            }
        }

        public ImmutableDictionary<DateTime, string> StudentFile
        {
            get
            {
                return studentFile.ToImmutableDictionary();
            }
        }

        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var registration = ImmutableList.CreateBuilder<CourseRegistration>();
                foreach (var stud in CourseRegistration.AllCourseRegistrations)
                {
                    if (stud.Student is not null && stud.Student is Student)
                    {
                        registration.Add(stud);
                    }
                }

                return registration.ToImmutableList();
            }
        }

        public ImmutableList<Course> Courses
        {
            get
            {
                var courses = ImmutableList.CreateBuilder<Course>();
                foreach (var course in CourseRegistrations)
                {
                    if (Equals(this) && course.Course is not null)
                    {
                        courses.Add(course.Course);
                    }
                }

                return courses.ToImmutable();
            }
        }

        public int Age
        {
            get
            {
                return base.Age;
            }
        }

        public override string GenerateNameCard()
        {
            return $"{base.Name} ({this.Age.ToString("F0")} jaar)";
        }

        public override double DetermineWorkload()
        {
            byte total = 0;

            foreach (CourseRegistration course in CourseRegistrations)
            {
                if (course is not null)
                {
                    total += 10;
                }
            }

            return total;
        }

        public void RegisterCourseResult(Course courseName, byte? result)
        {
            try
            {
                CourseRegistration course = new CourseRegistration(this, courseName, result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double Average()
        {
            double res = 0;
            int counter = 0;
            foreach (CourseRegistration cijfers in CourseRegistrations)
            {
                if (cijfers.Result != null)
                {
                    res += (byte)cijfers.Result;
                    counter++;
                }
            }

            return res / counter;
        }

        public void ShowOverview()
        {
            Console.WriteLine(this.GenerateNameCard());
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()}\n");
            Console.WriteLine("Cijferrapport\n*************");

            foreach (CourseRegistration course in CourseRegistrations)
            {
                Console.WriteLine($"{course.Course.Title}:  {course.Result}");
            }

            Console.WriteLine($"Gemiddelde: {Average().ToString("F1")}");

            Console.WriteLine();
        }

        public static void AddStudent()
        {
            try
            {
                Console.WriteLine("Naam van de student?");
                Console.Write("> ");
                string name = Console.ReadLine();
                Console.WriteLine("Geboortedatum van de student? (jaar/maand/dag)");
                Console.Write("> ");
                string date = Console.ReadLine();

                if (date is null)
                    throw new NullReferenceException("Geen datum is ingevoerd");

                DateTime birthDate = DateTime.Parse(date);

                Student newstu = new Student(name, birthDate);

                Console.Write("Student is corect toegevoegd, Druk op enter > ");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Druk op enter om door te gaan > ");
                Console.ReadKey();
            }
        }
    }
}