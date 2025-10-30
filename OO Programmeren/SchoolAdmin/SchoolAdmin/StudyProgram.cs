using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudyProgram
    {
        private string name;
        private readonly ImmutableList<Course> courses = ImmutableList<Course>.Empty;
        
        public StudyProgram(string name, List<Course> course)
        {
            this.Name = name;

            courses = course.ToImmutableList();
        }

        public StudyProgram(string name) : this(name, null)
        {
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public ImmutableList<Course> Courses
        {
            get
            {
                return courses.ToImmutableList();
            }
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{this.Name}");
            Console.WriteLine(String.Empty.PadLeft(this.Name.Length, '*'));

            foreach (Course course in Courses)
            {
                Console.WriteLine($"-{course.Title}");
            }

            Console.WriteLine();
        }

        public void Remove(string input)
        {
            foreach(Course course in courses)
            {
                if(this.Name != input)
                {
                    throw new Exception("Ingevoerde richting is er niet");
                }
                courses.Remove(course);
            }
        }
    }
}