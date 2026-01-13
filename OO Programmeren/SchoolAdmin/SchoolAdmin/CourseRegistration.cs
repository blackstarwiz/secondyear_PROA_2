using System.Collections.Immutable;

namespace SchoolAdmin
{
    //CourseRegistrationis bedoeld om naam een resultaat van een student bij te houden bij een bepaalde opleiding
    internal class CourseRegistration
    {
        private static List<CourseRegistration> allCourseRegistrations = new();
        private Course? course;
        private byte? result;
        private readonly Student student;

        //aantal student toegelaten in course
        private int maxStu = 20;

        //de aantal  students counter
        private int aantal = 1;

        public CourseRegistration(Student student, Course? course, byte? result)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student), "Student mag niet ontbreken!");
            this.student = student;
            this.Course = course;//check op null object -> property
            this.Result = result;//check op null object -> property

            //bekijken of max aantal studenten voor course bereikt is of niet
            foreach (var co in AllCourseRegistrations)
            {
                if (co.Course.Title == Course.Title)
                    aantal++;
            }

            //als het aantal gelijk is aan maxstu dan zal er een execption gegooit worden.
            if (aantal == maxStu && course is not null)
                throw new CapacityExceededException($"Max aantal studenten bereikt voor {Course.Title}");

            //als max aantal niet bereik is gaan we verder
            //voor elke registratie
            foreach (var registration in AllCourseRegistrations)
            {
                //als Course niet leeg is
                if (Course is not null)
                    //bekijken we of de student de klass in zijn lijst heeft staan
                    if (registration.student.Courses.Contains(Course))
                    {
                        //als dit zo is zullen we de id's van de lijst(studenten).id verglijkt worden met de ingevoerde student
                        // die zich wilt inschrijven
                        if (registration.student.Id == student.Id)
                            //als de student gelijk is stoppen we de terminal en gooien we exeption
                            throw new ArgumentOutOfRangeException($"Je kunt je niet dubbel inschrijven voor {Course.Title}");
                    }
            }

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

        public Student Student => student;

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