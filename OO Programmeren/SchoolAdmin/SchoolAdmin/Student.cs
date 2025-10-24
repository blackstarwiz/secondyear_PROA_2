using System.Collections.Immutable;
using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student : Person
    {
        private List<CourseRegistration> courseRegistrations = new();
        private static readonly ImmutableList<Student>.Builder allStudents = ImmutableList.CreateBuilder<Student>();
        private ImmutableDictionary<DateTime, string> studentFile = ImmutableDictionary<DateTime, string>.Empty;

        public Student(string name, DateTime birthdate) : base(name, birthdate) {
            allStudents.Add(this);
        }


        public ImmutableList<Student> Allstudents
        {
            get
            {
                return allStudents.ToImmutableList();
            }
        }

        public ImmutableDictionary<DateTime,string> StudentFile
        {
            get
            {
                return studentFile.ToImmutableDictionary();
            }
        }

        public int Age
        {
            get
            {
                return base.Age;
            }
        }

        public override string GenerateNameCard()
        {
            return $"{base.Name} ({this.Age.ToString("F0")} jaar)";
        }

        public override double DetermineWorkload()
        {
            byte total = 0;

            foreach(CourseRegistration course in courseRegistrations)
            {
                if(course is not null)
                {
                    total +=10;
                }
            }
            return total;
        }

        public void RegisterCourseResult(Course courseName, byte? result)
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
                Console.WriteLine($"{course.Course.Title}:  {course.Result}");
            }

            Console.WriteLine($"Gemiddelde: {Average().ToString("F1")}");

            Console.WriteLine();
            

        }
       
    }
}