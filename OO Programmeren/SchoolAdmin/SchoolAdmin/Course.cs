namespace SchoolAdmin
{
    //Course is bedoeld om te zien hoeveel studenten er in de opleiding zit
    internal class Course
    {
        public string Title;
        public List<Student> Students = new List<Student>();
        private byte creditPoints;
        private static int maxId = 1;
        private static List<Course> allCourses = new List<Course>();


        public Course(string title, List<Student> students, byte creditpoints) 
        {
            this.Title = title;
            this.Students = students;
            this.CreditPoints = creditpoints;
        }

        public Course(string title,List<Student> students)
        {
            this.Title = title;
            this.Students = students;
        }

        public Course(string title)
        {
            this.Title = title;
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
                return maxId;
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
            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();

            Course.maxId++;
        }
    }
}