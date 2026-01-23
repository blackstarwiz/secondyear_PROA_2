using System.Collections.Immutable;

namespace SchoolAdmin
{
    //CourseRegistrationis bedoeld om naam een resultaat van een student bij te houden bij een bepaalde opleiding
    public class CourseRegistration
    {
        private static List<CourseRegistration> allCourseRegistrations = new();
        private Course? course;
        private byte? result;
        private Student? student;

        //aantal student toegelaten in course
        private int maxStu = 20;

        //de aantal  students counter
        private int aantal = 1;

        public CourseRegistration(Student? student, Course? course, byte? result)
        {
            this.student = student;
            this.course = course;//check op null object -> property
            this.Result = result;//check op null object -> property

            //bekijken of max aantal studenten voor course bereikt is of niet
            foreach (var co in AllCourseRegistrations)
            {
                if (co is null || Course is null)
                    throw new ArgumentNullException("Course is leeg");
                if (co.Course is null)
                    throw new ArgumentNullException("Students Course is leeg");
                if (co.Course.Title == Course.Title)
                    aantal++;
            }

            //als het aantal gelijk is aan maxstu dan zal er een execption gegooit worden.
            if (aantal == maxStu && Course is not null)
                throw new CapacityExceededException($"Max aantal studenten bereikt voor {Course.Title}");

            //als max aantal niet bereik is gaan we verder
            //voor elke registratie
            foreach (var registration in AllCourseRegistrations)
            {
                //als Course niet leeg is
                if (Course is not null && Student is not null)
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
            Student? targetStudent;
            Course? targetCourse;

            //We halen lijst op van object Person en Course
            var studenten = Person.AllPersons.OfType<Student>().ToList();
            var courses = Course.AllCourses.ToList();

            if (studenten.Count == 0)

                throw new ArgumentNullException("Er zijn nog geen studenten toegevoegt.");

            if (courses.Count == 0)

                throw new ArgumentNullException("Er zijn nog geen courses toevoegt");

            Console.WriteLine("Welke student?");

            //Voor elke student in studenten geven we de hun id en hun naam
            Console.WriteLine($"0: null");
            foreach (var student in studenten)
            {
                Console.WriteLine($"{student.Id}: {student.Name}");
            }

            Console.Write("> ");
            //Als ingevoerde waarde een string is
            if (!int.TryParse(Console.ReadLine(), out int keuzeStu))
                throw new FormatException("Voer geldige keuzen in");

            if (keuzeStu > studenten.Count)
                throw new ArgumentOutOfRangeException("Ingevoerde optie bestaat niet");

            //Als keuze 0 = terug gaan
            if (keuzeStu == 0)
            {
                targetStudent = null;
            }
            else
            {
                //De keuze wordt gebruikt om het juist Student Object te vinden
                targetStudent = studenten.ElementAt(keuzeStu);
            }

            //-------------------------------------------------------------------------------------//

            Console.WriteLine("Welke course?");

            //Voor elke course in courses tonen we de id en title
            Console.WriteLine($"0: null");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Id}: {course.Title}");
            }

            if (!int.TryParse(Console.ReadLine(), out int keuzeCo))
                throw new FormatException("Voer geldige waarde in");

            if (keuzeCo == 0)
            {
                targetCourse = null;
            }
            else
            {
                targetCourse = courses.ElementAt(keuzeCo);
            }

            //------------------------------------------------------------------------------------------------------

            //resultaat toevoegen? aan student -- course: result

            Console.WriteLine("Wil je een resultaat toekennen? ja/nee");
            Console.Write("> ");

            string awnser;

            if (int.TryParse(awnser = Console.ReadLine() ?? "", out int number))
                throw new FormatException("Voer geldige waarden in");

            switch (awnser)
            {
                case "ja":
                case "Ja":
                case "JA":
                case "jA":
                    Console.WriteLine("Voer resultaat in");
                    Console.Write("> ");

                    if (!byte.TryParse(Console.ReadLine(), out byte result))
                        throw new FormatException("Voer geldige waarde in");
                    if (result < 0)
                        throw new ArgumentNullException("Waarde moet positief zijn");

                    new CourseRegistration(targetStudent, targetCourse, result);

                    break;

                default:
                    return;
            }

            //CourseRegistration newRegistration = new CourseRegistration(selectedStudent, selectedCourse, result);

            Console.Write("Registratie is correct verlopen, Druk op Enter > ");
            Console.ReadKey();
        }
    }
}