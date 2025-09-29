namespace SchoolAdmin
{
    internal class Course
    {
        public string Title;
        public List<Student> Students = new List<Student>();
        private byte creditPoints;
        private static int maxId = 1;
        private static List<Course> allCourses = new List<Course>();

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
            Console.WriteLine($"{this.Title}");

            foreach (Student person in Students)
            {
                Console.WriteLine($"{person.Name}");
            }
        }
    }
}