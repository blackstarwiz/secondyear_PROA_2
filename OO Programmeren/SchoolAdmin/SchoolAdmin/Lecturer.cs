using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Lecturer : Employee
    {
        private ImmutableDictionary<Course, byte> allCourses = ImmutableDictionary<Course, byte>.Empty;

        public Lecturer(string name, DateTime birthdate, Dictionary<string, byte> courses) : base(name, birthdate, courses)
        {
            if (courses != null)
            {
                foreach (var course in courses)
                {
                    allCourses.Add(new Course(course.Key), course.Value);
                }
            }
        }

        public Lecturer AllLecturer
        {
            get
            {
                return this;
            }
        }

        public ImmutableDictionary<Course, byte> AllCourses
        {
            get
            {
                return allCourses;
            }
        }

        public override uint CalculateSalary()
        {
            uint basisSalary = 2200;
            uint resultSalary = 0;

            if (this.Seniority >= 4)
            {
                //jaren dienst ==> decimal years
                var y = this.Seniority / 4;
                decimal years = Math.Floor(Convert.ToDecimal(y));

                //werkbelasting ophalen van werknemen
                double workload = this.DetermineWorkload();

                //basis + accientiteit x workload / voltijdswerk(40u);
                resultSalary = Convert.ToUInt32((basisSalary + Convert.ToUInt32((years * 120))) * workload / 40);
            }
            else
            {
                resultSalary = basisSalary;
            }

            return resultSalary;
        }

        public override double DetermineWorkload()
        {
            return AllCourses.Values.Sum(v => (double)v);
        }

        public override string GenerateNameCard()
        {
            return $"{this.Name} \nLector voor:";
        }
    }
}