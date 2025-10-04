using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student
    {
        public string Name;
        public DateTime Birthdate;
        public uint StudentNumber;
        private List<CourseRegistration> courseRegistrations = new List<CourseRegistration>();
        public static uint StudentCounter = 1;
        

        public Student(string name, DateTime birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public int Age
        {
            get
            {
                TimeSpan age = DateTime.Now - Birthdate;
                return age.Days / 365;
            }
        }

        public string GenerateNameCard()
        {
            return $"{this.Name} ({this.Age.ToString("F0")} jaar)";
        }

        public byte DetermineWorkload()
        {
            return (byte)(courseRegistrations.Count * 10);
        }

        public void RegisterCourseResult(string courseName, byte? result)
        {
            
            try
            {
                CourseRegistration course = new CourseRegistration(courseName, result);
                
                courseRegistrations.Add(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double Average()
        {
            double res = 0;
            int counter = 0;
            foreach (CourseRegistration cijfers in courseRegistrations)
            {
                if(cijfers.Result != null)
                {
                    res += (byte) cijfers.Result;
                    counter++;
                } 
            }

            return res / counter;
        }

        public void ShowOverview()
        {
            Console.WriteLine(this.GenerateNameCard());
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()}\n");
            Console.WriteLine("Cijferrapport\n*************");

            foreach (CourseRegistration course in courseRegistrations)
            {
                Console.WriteLine($"{course.Name}:  {course.Result}");
            }

            Console.WriteLine($"Gemiddelde: {Average().ToString("F1")}");

            Console.WriteLine();
            

        }
    }
}