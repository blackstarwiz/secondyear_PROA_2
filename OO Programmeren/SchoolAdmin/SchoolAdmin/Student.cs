using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student
    {
        public string Name;
        public DateTime Birthdate;
        public uint StudentNumber;
        private List<CourseResult> courseResults = new List<CourseResult>();
        public static uint StudentCounter = 1;
        private int age;


        public int Age
        {
            get
            {
                TimeSpan age =  DateTime.Now - Birthdate;
                return age.Days / 365;
            }
        }
        public string GenerateNameCard()
        {
            return $"{this.Name} ({this.Age.ToString("F0")} jaar)";
        }

        public byte DetermineWorkload()
        {
            return (byte)(courseResults.Count * 10);
        }

        public void RegisterCourseResult(string course, byte result)
        {
            CourseResult courses = new CourseResult();
            try
            {
                courses.Result = result;
                courses.Name = course;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double Average()
        {
            double res = 0;
            foreach (CourseResult cijfers in courseResults)
            {
                res += cijfers.Result;
            }

            return res / courseResults.Count;
        }

        public void ShowOverview()
        {
            Console.WriteLine(this.GenerateNameCard());
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()}\n");
            Console.WriteLine("Cijferrapport\n*************");

            foreach (CourseResult course in courseResults)
            {
                Console.WriteLine($"{course.Name}:  {course.Result}");
            }

            Console.WriteLine($"Gemiddelde: {Average().ToString("F1")}");

            Console.WriteLine();
        }
    }
}