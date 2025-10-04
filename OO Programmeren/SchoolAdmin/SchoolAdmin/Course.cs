namespace SchoolAdmin
{
    //Course is bedoeld om te zien hoeveel studenten er in de opleiding zit
    internal class Course
    {
        public string Title;
        public List<Student> Students = new List<Student>();
        private byte creditPoints;
        public int id;
        private static int maxId = 1;
        public static List<Course> AllCourses = new List<Course>();

        public Course(string title, List<Student> students, byte creditpoints)
        {
            this.Id = maxId++;

            this.Title = title;
            this.Students = students;
            this.CreditPoints = creditpoints;
            
            Course.AllCourses.Add(this);
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

        public void ShowOverview()
        {
            Console.WriteLine($"{this.Title} ({this.Id}) ({this.CreditPoints}stp)");
            Console.WriteLine(String.Empty.PadLeft(this.Title.Length, '*'));

            foreach (Student person in Students)
            {
                Console.WriteLine($"{person.Name}");
            }
           
        }

        public static Course SearchCourseById(int id)
        {
            foreach (Course c in AllCourses)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }

            return null;
        }
    }
}