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
        

        public string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public byte DetermineWorkload()
        {
            return (byte)(courseResults.Count * 10);
        }

        public void RegisterCourseResult(string course, byte result)
        {
            CourseResult courses = new CourseResult();
            if (result > 20)
            {
                Console.WriteLine("Ongeldig Cijfer");
            }
            else
            {
                courses.Name = course;
                courses.Result = result;

                courseResults.Add(courses);
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