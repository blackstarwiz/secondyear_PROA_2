namespace SchoolAdmin
{
    internal class Course
    {
        public string Title;
        public List<Student> Students = new List<Student>();

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