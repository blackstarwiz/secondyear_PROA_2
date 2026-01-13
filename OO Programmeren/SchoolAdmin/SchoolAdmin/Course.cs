using System;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    internal class Course
    {
        public string Title;
        private readonly ImmutableList<Student> students;
        private byte creditPoints;

        private int id;
        private static int maxId = 1;
        public static ImmutableList<Course>.Builder AllCourses = ImmutableList.CreateBuilder<Course>();

        

        public Course(string title, byte creditpoints)
        {
            //voor elke bestaande course
            foreach (Course existingCourse in AllCourses)
            {
                //als deze de zelfde titel heeft gooien we een exception DuplicateDataException
                if (existingCourse.Title == title)
                {
                    throw new DuplicateDataException("Nieuwe cursus heeft dezelfde naam als een bestaande cursus", this, existingCourse);
                }
            }

            this.Id = maxId++;
            this.Title = title;

            this.CreditPoints = creditpoints;

            AllCourses.Add(this);
        }

        public Course(string title) : this(title, 3)
        {
        }

        public ImmutableList<Student> Students
        {
            get
            {
                var students = ImmutableList.CreateBuilder<Student>();

                foreach (var person in Person.AllPersons)
                {
                    if (person is Student student)
                        students.Add(student);
                }
                return students.ToImmutable();
            }
        }

        public byte CreditPoints
        {
            get
            {
                return creditPoints;
            }
            private set
            {
                creditPoints = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }

        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var courses = ImmutableList.CreateBuilder<CourseRegistration>();
                foreach (var course in CourseRegistration.AllCourseRegistrations)
                {
                    if (Equals(course))
                    {
                        courses.Add(course);
                    }
                }

                return courses.ToImmutable();
            }
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is null))
                return obj is Course other && Id == other.Id;
            throw new ArgumentNullException("Course in leeg");
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{this.Title} ({this.Id}) ({this.CreditPoints}stp)");
            Console.WriteLine(String.Empty.PadLeft(this.Title.Length, '*'));
            var studentS = Students;
            foreach (Student person in this.Students)
            {
                if (!(person is null))
                {
                    Console.WriteLine($"{person.Name}");
                }
            }

            Console.WriteLine();
        }

        public static Course SearchCourseById(int id)
        {
            foreach (Course c in AllCourses)
            {
                if (id == c.Id)
                {
                    return c;
                }
            }

            return null;
        }

        public static void AddCourse()
        {
            Console.WriteLine("Titel van de cursus?");
            Console.Write("> ");
            string course = Console.ReadLine();

            Console.WriteLine("Aantal studiepunten?");
            Console.Write("> ");
            byte points = Convert.ToByte(Console.ReadLine());

            try
            {
                Course newCourse = new Course(course, points);
                Console.Write("Druk op enter om door te gaan > ");
                Console.ReadKey();
            }
            catch (DuplicateDataException e)
            {
                //eerst komt er een error message die meegeven is bij de constructor Course
                Console.WriteLine(e.Message);
                //Als het bestaande type klasse Course is geven we extra message om te melden welke id de course heeft
                if (e.Object2 is Course bestaandeCourse)
                {
                    //hiervoor gebruiken we de ID van BestaandeCourse
                    Console.WriteLine($"Id van de reeds bestaande cursus is: {bestaandeCourse.Id}");
                }
                Console.Write("Vak is correct toegevoegd, Druk op Enter > ");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Onverwachte fout: {ex.Message}");
                Console.Write("Druk op enter om door te gaan > ");
                Console.ReadKey();
            }
        }


        //DEMO'S
        public static void DemoCourses()
        {
            try
            {
                //student objecten maken
                
                Student student1 = new Student("Jason Meulemans", new DateTime(1998, 1, 1));

                Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));

                //Course object aanmaken en studenten toevoegen plus studiepunten
                Course webCourse = new Course("Webtechnologie", 6);

                Course oopCourse = new Course("OO Programmeren");

                Course wplCours = new Course("WPL",9);

                student1.RegisterCourseResult(webCourse, 4);
                student1.RegisterCourseResult(webCourse, 4);//dubbele invoer MAG NIET!!
                student1.RegisterCourseResult(oopCourse, 7);
                student1.RegisterCourseResult(wplCours, 0);

                student2.RegisterCourseResult(webCourse,0);
                student2.RegisterCourseResult(oopCourse, 2);
                student2.RegisterCourseResult(wplCours, 14);
                
                webCourse.ShowOverview();
                oopCourse.ShowOverview();
                wplCours.ShowOverview();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }
    }
}