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
    }
}