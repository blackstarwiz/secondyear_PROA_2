namespace SchoolAdmin
{
    //CourseRegistrationis bedoeld om naam een resultaat van een student bij te houden bij een bepaalde opleiding
    internal class CourseRegistration
    {
        private Course course;
        private byte? result;

        public CourseRegistration(Course course, byte? result)
        {
            this.Course = course;
            this.Result = result;
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
    }
}