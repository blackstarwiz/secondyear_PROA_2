using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class Student : Person, IIntershipable
    {

        private TimeSpan hours;
        private string company;
        //AANGEPAST VOOR EXAMEN
        private ClassGroup classGroup;
        public ClassGroup ClassGroup
        {
            get { return classGroup; }
            private set { classGroup = value; }
        }
        //

        public ImmutableList<CourseRegistration> CourseRegistrations
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<CourseRegistration>();
                foreach (var registration in CourseRegistration.AllCourseRegistrations)
                {
                    if (this == registration.Student)
                    {
                        builder.Add(registration);
                    }
                }
                return builder.ToImmutable();
            }
        }

        public ImmutableList<Course> Courses
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<Course>();
                foreach (var registration in this.CourseRegistrations)
                {
                    builder.Add(registration.Course);
                }
                return builder.ToImmutable();
            }
        }

        public static ImmutableList<Student> AllStudents
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<Student>();
                foreach (Person persoon in Person.AllPersons)
                {
                    if (persoon is Student)
                    {
                        builder.Add((Student)persoon);
                    }
                }
                return builder.ToImmutableList<Student>();
            }
        }

        //AANGEPAST VOOR EXAMEN
        public Student(string name, DateTime birthDate) : this(name, birthDate, new ClassGroupPicker())
        {
        }
        public Student(string name, DateTime birthDate, IClassGroupPicker classGroupPicker) : base(name, birthDate)
        {
            ClassGroup = classGroupPicker.PickClass();
            if (Age < 18)
            {
                throw new TooYoungException($"{name} is te jong om aan de hogeschool te studeren.");
            }
        }
        //


        public TimeSpan Hours
        {
            get
            {
                return hours;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }


        public void PrintInternshipInfo()
        {
            Console.WriteLine($"'{Name}' doet WPL bij '{Company}'");
        }

        public override string GenerateNameCard()
        {
            return $"{this.Name} (STUDENT)";
        }

        public override double DetermineWorkload()
        {
            double total = 0;
            foreach (CourseRegistration course in CourseRegistrations)
            {
                if (course is not null)
                {
                    total += 10;
                }
            }
            return total;
        }

        public void RegisterCourseResult(Course course, byte? result)
        {
            if (result > 20)
            {
                Console.WriteLine("Ongeldig cijfer!");
            }
            else
            {
                new CourseRegistration(this, course, result);

            }
        }
        public double Average()
        {
            double total = 0;
            int counter = 0;
            foreach (CourseRegistration item in CourseRegistrations)
            {
                if (!(item.Result is null))
                {
                    total += (byte)item.Result;
                    counter++;
                }
            }
            return total / counter;
        }

        public void ShowOverview()
        {
            Console.WriteLine($"{this.Name} ({Age} jaar)");
            Console.WriteLine($"Werkbelasting: {DetermineWorkload()} uren");
            Console.WriteLine("Cijferrapport");
            Console.WriteLine("*************");
            foreach (CourseRegistration item in CourseRegistrations)
            {
                Console.WriteLine($"{item.Course.Title}:\t{item.Result}");
            }
            Console.WriteLine($"Gemiddelde:\t{this.Average():F1}\n");
        }
        
        //AANGEPAST VOOR EXAMEN
        public override string ToString()
        {
            return base.ToString() + $"\nStudent uit klasgroep {ClassGroup}";
        }
        //
       
        public override string ToCSV()
        {
            return "Student;" + base.ToCSV();
        }

    }
}
