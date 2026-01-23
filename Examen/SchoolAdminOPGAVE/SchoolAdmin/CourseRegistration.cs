using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class CourseRegistration
    {
        private Course course;
        public Course Course
        {
            get { return course; }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Cursus mag niet ontbreken.");
                }
                course = value;
            }
        }
        private byte? result;
        public byte? Result
        {
            get
            {
                return result;
            }
            set
            {
                if (!(value is null) && !(value > 20))
                {
                    result = value;
                }
            }
        }

        private static List<CourseRegistration> allCourseRegistrations = new List<CourseRegistration>();
        public static ImmutableList<CourseRegistration> AllCourseRegistrations
        {
            get { return allCourseRegistrations.ToImmutableList(); }
        }

        private Student student;
        public Student Student
        {
            get
            {
                return student;
            }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Student mag niet ontbreken.");

                }
                student = value;
            }
        }

        public CourseRegistration(Student student, Course course, byte? result)
        {
            this.Course = course;
            this.Result = result;
            this.Student = student;
            int counter = 0;
            foreach (CourseRegistration item in AllCourseRegistrations)
            {
                if(item.Course==course && item.Student==student)
                {
                    throw new ArgumentException("Een student kan niet meermaals inschrijven voor dezelfde cursus.");
                }
                else if(item.Course==course & item.Result is null)
                {
                    counter++;
                }
            }
            if (counter>=1 && result is null)
            {
                throw new CapacityExceededException($"Er zijn al teveel studenten ingeschreven voor {Course.Title}");
            }
            allCourseRegistrations.Add(this);
        }

        
    }
}

