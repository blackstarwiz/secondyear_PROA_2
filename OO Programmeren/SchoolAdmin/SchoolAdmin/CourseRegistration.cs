using System.Collections.Immutable;

namespace SchoolAdmin
{
    //CourseRegistrationis bedoeld om naam een resultaat van een student bij te houden bij een bepaalde opleiding
    internal class CourseRegistration
    {
        private static List<CourseRegistration> allCourseRegistrations = new ();
        private Course course;
        private byte? result;
        private Student student;

        public CourseRegistration(Student student, Course course, byte? result)
        {
            this.Course = course;
            this.Result = result;
            this.student = student;

            allCourseRegistrations.Add(this);
        }

        public Course Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
            }
        }

        public byte? Result
        {
            get
            {
                return result;
            }
            set
            {
                if (value is null || value > 20)
                {
                    throw new Exception("Ingevoerde waarde is null of hoger dan 20");
                }
                result = value;
            }
        }

        public static ImmutableList<CourseRegistration> AllCourseRegistrations
        {
            get
            {
                return allCourseRegistrations.ToImmutableList();
            }
        }

        public Student Student
        {
            get
            {
                return student;
            }
        }
    }
}