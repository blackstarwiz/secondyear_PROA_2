using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student
    {

        public string Naam;
        public DateTime GeboorteDatum;
        public uint StudentNumber;
        private List<CourseResult> courseResults = new List<CourseResult>();
        public static uint StudentenTeller = 1;

        public string GenereerNaamKaartje()
        {
            return $"{this.Naam} (STUDENT)";
        }

        public byte DeterminWorkLoad()
        {
            byte total = 0;

            foreach(string course in courses)
            {
                total += 10;
            }
        }

        public void RegisterCourseResult(string course, byte result)
        {
            CourseResult courses = new CourseResult();

            if(courses.Result > 20)
            {
                Console.WriteLine("Ongeldig Cijfer");
            }
            
            courses.Name = course;


        }
    }
}