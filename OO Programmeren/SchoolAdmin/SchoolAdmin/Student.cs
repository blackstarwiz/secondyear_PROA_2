using System.Collections.Immutable;
using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student : Person
    {
        private ImmutableDictionary<DateTime, string> studentFile = ImmutableDictionary<DateTime, string>.Empty;

        public Student(string name, DateTime birthdate) : base(name, birthdate)
        {
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

        //geef een lijst terug van al de registraties van de student
        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var registrations = ImmutableList.CreateBuilder<CourseRegistration>();
                foreach (var registration in CourseRegistration.AllCourseRegistrations)
                {
                    if (this.Name == registration.Student.Name)
                    {
                        registrations.Add(registration);
                    }
                }

                return registrations.ToImmutableList();
            }
        }

        public ImmutableList<Course> Courses
        {
            get
            {
                var courses = ImmutableList.CreateBuilder<Course>();
                foreach (var course in CourseRegistrations)
                {
                    if (Name == course.Student.Name && course.Course is not null)
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
                new CourseRegistration(this, courseName, result);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ActualValue);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (CapacityExceededException e)
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
            
            var studentName = this.GenerateNameCard();
            var cijferRapport = "Cijferrapport";

            //Student en werktbelasting
            Console.WriteLine(studentName);
            Console.WriteLine(String.Empty.PadLeft(studentName.Length, '*'));
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()}");
            //SPACE
            Console.WriteLine();
            //CijferRapport
            Console.WriteLine(cijferRapport);
            Console.WriteLine(string.Empty.PadLeft(cijferRapport.Length,'*'));

            foreach (CourseRegistration course in CourseRegistrations)
            {
                if (course.Course is null)
                    throw new ArgumentNullException();

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


        //DEMO'S
        public static void DemoStudents()
        {
            //student objecten maken
            Student student1 = new Student("Said Aziz", new DateTime(2000, 6, 1));
            Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));
           

            //Course object aanmaken en studenten toevoegen plus studiepunten
            Course webCourse = new Course("Webtechnologie", 6);

            Course oopCourse = new Course("OO Programmeren");

            Course wplCours = new Course("WPL", 9);

            student1.RegisterCourseResult(webCourse, 4);
            student1.RegisterCourseResult(webCourse, 4);//dubbele invoer MAG NIET!!
            student1.RegisterCourseResult(oopCourse, 7);
            student1.RegisterCourseResult(wplCours, 0);

            student2.RegisterCourseResult(webCourse, 0);
            student2.RegisterCourseResult(oopCourse, 2);
            student2.RegisterCourseResult(wplCours, 14);

            //Beeld schoon maken
            Console.Clear();

            student1.ShowOverview();
            student2.ShowOverview();

            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }


    }
}