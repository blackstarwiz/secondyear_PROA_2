using System.Collections.Immutable;

namespace SchoolAdmin
{
    //CourseRegistrationis bedoeld om naam een resultaat van een student bij te houden bij een bepaalde opleiding
    internal class CourseRegistration
    {
        private static List<CourseRegistration> allCourseRegistrations = new();
        private Course? course;
        private byte? result;
        private Student? student;

        public CourseRegistration(Student? student, Course? course, byte? result)
        {
            this.Course = course;//check op null object -> property
            this.Student = student;//check op null object ->property
            this.Result = result;




            //aantal student toegelaten in course
            int maxStu = 20;
            //de aantal  students counter 
            int aantal = 0;
            //voor elke registratie
            foreach(var stu in AllCourseRegistrations)
            {
                
                //bekijken we of deze niet null is van bestaande en binnen komende Object, ook bekijken we de id  of deze het zelfde is al gekozen course
                if(stu.Course is not null && course is not null && stu.Course.Equals(course) && stu.Student is not null)
                {
                    foreach(var courses in stu.Student.Courses)
                    {
                        if (courses == course)
                            throw new ArgumentException("Een student kan niet meermaals inschrijven voor dezelfde cursus.");
                    }
                    //als Result = 0 
                    if(stu.Result == 0)
                    {
                        aantal++;
                    }
                }
            }
               
            if (aantal >= maxStu)
                throw new CapacityExceededException($"Er zijn al teveel studenten ingeschreven voor {course.Title}");

            allCourseRegistrations.Add(this);
        }

        public Course? Course
        {
            get
            {
                return course;
            }
            private set
            {
                if (value is null)
                    throw new ArgumentException("Cursus mag niet ontbreken");
                course = value;
            }
        }

        public Student? Student
        {
            get
            {
                return student;
            }
            private set
            {
                if (value is null)
                    throw new ArgumentException("Student mag niet ontbreken");
                student = value;
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
                    throw new Exception("Ingevoerde waarde is null of hoger dan 20");

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

        public static void AddCourseRegistration()
        {
            try
            {
                //new list Student met extra null object als optie 0
                var studenten = new List<Student?>() { null };

                //Welke student
                Console.WriteLine("Welke student?");
                Console.WriteLine("0. null");

                //loop door bestaande list van Person
                for (int i = 0; i < Person.AllPersons.Count; i++)
                {
                    //als person object is van type student
                    if (Person.AllPersons[i] is Student)
                    {
                        //toon dan de student
                        Console.WriteLine($"{i + 1}: {Person.AllPersons[i].Name}");

                        //dan toevoegen aan nieuwe list studenten met toegevoegde optie 0{null}
                        studenten.Add((Student)Person.AllPersons[i]);
                    }
                }

                Console.Write("> ");

                int choiceStudent = Convert.ToInt32(Console.ReadLine());

                Student? selectedStudent = studenten[choiceStudent];

                //Welke cursus

                //new list Courses met extra null object optie  0
                var courses = new List<Course?>() { null };
                Console.WriteLine("Welke cursus?");

                Console.WriteLine("0. null");

                //loop door bestaande list Course
                for (int i = 0; i < Course.AllCourses.Count; i++)
                {
                    //voorbeeld { 1: course.title(Programmeren)}
                    Console.WriteLine($"{i + 1}: {Course.AllCourses[i].Title}");
                    //toevoegen aan nieuwe list courses met toegevoegde optie 0{null object}
                    courses.Add(Course.AllCourses[i]);
                }

                Console.Write("> ");

                int choiceCourse = Convert.ToInt32(Console.ReadLine());

                //choiceCourse int (position) pakken en en deze om zetten als object course
                Course? selectedCourse = courses[choiceCourse];

                //result toevoegen ja of nee
                Console.WriteLine("Wil je een resultaat toekennen? ja/nee");
                Console.Write("> ");
                string choiceResult = Console.ReadLine();
                byte result = 0;

                if (choiceResult == "ja")
                {
                    Console.WriteLine("Wat is het resultaat");
                    Console.Write("> ");
                    result = Convert.ToByte(Console.ReadLine());
                }

                CourseRegistration newRegistration = new CourseRegistration(selectedStudent, selectedCourse, result);

                Console.Write("Registratie is correct verlopen, Druk op Enter > ");
                Console.ReadKey();
            }
            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
                Console.Write("Druk op enter om door te gaan > ");
                Console.ReadKey();
            }
            catch (CapacityExceededException c)
            {
                Console.WriteLine(c.Message);
                Console.Write("Druk op enter om door te gaan > ");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Druk op enter om door te gaan > ");
                Console.ReadKey();
            }
        }
    }
}