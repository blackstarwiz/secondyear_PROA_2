﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudyProgram
    {
        private string name;
        private List<Course> courses;

        public StudyProgram(string name, List<Course> courses)
        {
            this.Name = name;
            this.Courses = courses ?? new List<Course>();
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

        public List<Course> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
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
    }
}