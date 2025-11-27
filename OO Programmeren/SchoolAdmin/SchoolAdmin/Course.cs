using System.Collections.Immutable;

namespace SchoolAdmin
{
    //Course is bedoeld om te zien hoeveel studenten er in de opleiding zit
    internal class Course
    {
        public string Title;
        //public List<Student> Students = new List<Student>();
        private byte creditPoints;
        private int id;
        private static int maxId = 1;
        public static ImmutableList<Course>.Builder AllCourses = ImmutableList.CreateBuilder<Course>();

        public Course(string title, byte creditpoints)
        {
            //voor elke bestaande course
            foreach(Course existingCourse in AllCourses)
            {
                //als deze de zelfde titel heeft gooien we een exception DuplicateDataException
                if (existingCourse.Title == title)
                {
                    throw new DuplicateDataException("Nieuwe cursus heeft dezelfde naam als een bestaande cursus", this, existingCourse);
                }
            }

            this.Id = maxId++;
            this.Title = title;
            //this.Students = students ?? new List<Student>();
            this.CreditPoints = creditpoints;

            AllCourses.Add(this);
        }

        public Course(string title) : this(title, 3)
        {
        }

        /// 
        /// public Course(string title) : this(title, null, 3)
        //{
        //}
        /// 
        /// 
        
        public ImmutableList<Student> Students
        {
            get
            {
                var students = ImmutableList.CreateBuilder<Student>();

                foreach(var student in CourseRegistrations)
                {
                    if (Equals(student.Student))
                    {
                        students.Add(student.Student);
                    }
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
                foreach (var course in CourseRegistrations)
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
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{this.Title} ({this.Id}) ({this.CreditPoints}stp)");
            Console.WriteLine(String.Empty.PadLeft(this.Title.Length, '*'));

            //if (Students is null)
            //{
            //    throw new NullReferenceException("fuck ik ben leeg");
            //}

            foreach (Student person in Students)
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
    }
}