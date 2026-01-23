using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace SchoolAdmin
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("1. Demonstreer studenten uitvoeren");
                Console.WriteLine("2. Demonstreer cursussen uitvoeren");
                Console.WriteLine("3. Student uit tekstformaat inlezen");
                Console.WriteLine("4. Demonstreer studieProgramma uitvoeren");
                Console.WriteLine("5. Demonstreer administratiefPersoneel uitvoeren");
                Console.WriteLine("6. Demonstreer lectoren uitvoeren");
                Console.WriteLine("7. Student toevoegen");
                Console.WriteLine("8. Cursus toevoegen");
                Console.WriteLine("9. VakInschrijving toevoegen");
                Console.WriteLine("10. Inschrijvingsgegevens tonen");
                Console.WriteLine("11. Studenten tonen");
                Console.WriteLine("12. Cursussen tonen");
                Console.WriteLine("13. Data exporteren");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DemoStudents();
                        break;
                    case 2:
                        DemoCourses();
                        break;
                    case 3:
                        ReadTextFormatStudent();
                        break;
                    case 4:
                        StudyProgram.DemoStudyProgram();
                        break;
                    case 5:
                        DemoAdministrativePersonnel();
                        break;
                    case 6:
                        DemoLecturers();
                        break;
                    case 7:
                        AddStudent();
                        break;
                    case 8:
                        AddCourse();
                        break;
                    case 9:
                        AddCourseRegistration();
                        break;
                    case 10:
                        ShowCourseRegistrations();
                        break;
                    case 11:
                        ShowStudents();
                        break;
                    case 12:
                        ShowCourses();
                        break;
                    case 13:
                        Export();
                        break;
                    default:
                        break;
                }
            }

        }

        public static void DemoStudents()
        {
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course webtechnologie = new Course("Webtechnologie");
            Course databanken = new Course("Databanken");

            Student said = new Student("Said Aziz", new DateTime(2000, 6, 1));
            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, null);
            said.RegisterCourseResult(webtechnologie, 13);
            said.ShowOverview();

            Student mieke = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));
            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);
            mieke.ShowOverview();
        }
        public static void DemoCourses()
        {
            Student said = new Student("Said Aziz", new DateTime(2000, 6, 1));
            Student mieke = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));

            Course communicatie = new Course("Communicatie", 6);
            Course programmeren = new Course("Programmeren");

            Course webtechnologie = new Course("Webtechnologie");
            Course databanken = new Course("Databanken");

            said.RegisterCourseResult(communicatie, 12);
            said.RegisterCourseResult(programmeren, null);
            said.RegisterCourseResult(webtechnologie, 13);

            mieke.RegisterCourseResult(communicatie, 13);
            mieke.RegisterCourseResult(programmeren, 16);
            mieke.RegisterCourseResult(databanken, 14);

            communicatie.ShowOverview();
            programmeren.ShowOverview();
            webtechnologie.ShowOverview();
            databanken.ShowOverview();



        }

        public static void ReadTextFormatStudent()
        {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in csv-formaat:");
            string csv = Console.ReadLine();
            string[] data = csv.Split(";");
            int day = Convert.ToInt32(data[1]);
            int month = Convert.ToInt32(data[2]);
            int year = Convert.ToInt32(data[3]);
            Student newStudent = new Student(data[0], new DateTime(year, month, day));
            for (int i = 4; i < data.Length; i += 2)
            {
                int subjectID = Convert.ToInt32(data[i]);
                Course subject = Course.SearchCourseById(subjectID);
                if (!(subject is null))
                {
                    byte result = Convert.ToByte(data[i + 1]);
                    newStudent.RegisterCourseResult(subject, result);
                }
            }
            newStudent.ShowOverview();
        }

        public static void DemoAdministrativePersonnel()
        {
            var tasks = new Dictionary<string, byte>();
            tasks.Add("roostering", 10);
            tasks.Add("correspondentie", 10);
            tasks.Add("animatie", 10);
            AdministrativePersonnel ahmed = new AdministrativePersonnel("Ahmed Azzaoui", new DateTime(1988, 2, 4), tasks);
            ahmed.Seniority = 4;
            foreach (var personeel in AdministrativePersonnel.AllAdministrativePersonnel)
            {
                Console.WriteLine(personeel.GenerateNameCard());
            }
            Console.WriteLine(ahmed.CalculateSalary());
            Console.WriteLine(ahmed.DetermineWorkload());

        }
        public static void DemoLecturers()
        {
            var tasks = new Dictionary<string, byte>();
            var economie = new Course("Economie");
            var statistiek = new Course("Statistiek");
            var analytischeMeetkunde = new Course("Analytische meetkunde");
            var anna = new Lecturer("Anna Bolzano", new DateTime(1975, 6, 12), tasks);
            anna.Courses.Add(economie, 3);
            anna.Courses.Add(statistiek, 3);
            anna.Courses.Add(analytischeMeetkunde, 4);
            anna.Seniority = 9;
            foreach (var personeel in Lecturer.AllLecturers)
            {
                Console.WriteLine(personeel.GenerateNameCard());
            }
            Console.WriteLine(anna.CalculateSalary());
            Console.WriteLine(anna.DetermineWorkload());
        }
        public static void AddStudent()
        {
            Console.WriteLine("Naam van de student?");
            string name = Console.ReadLine();
            Console.WriteLine("Geboortedatum van de student?");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
            new Student(name, birthDate);
        }
        public static void AddCourse()
        {
            Console.WriteLine("Titel van de cursus?");
            string title = Console.ReadLine();
            Console.WriteLine("Aantal studiepunten?");
            byte creditPoints = Convert.ToByte(Console.ReadLine());

            try
            {
                new Course(title, creditPoints);
            }
            catch (DuplicateDataException exDDE)
            {
                Console.WriteLine(exDDE.Message);
                Console.WriteLine($"Id van de reeds bestaande cursus is: {((Course)exDDE.Object2).Id}");
            }
        }
        public static void AddCourseRegistration()
        {
            if (Student.AllStudents.Count < 1 || Course.AllCourses.Count < 1)
            {
                Console.WriteLine("Er moet minstens één student en minstens één cursus in het systeem zijn.");
            }
            else
            {
                Console.WriteLine("Welke student?");
                Console.WriteLine("0. null");
                for (int i = 0; i < Student.AllStudents.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {Student.AllStudents[i].Name}");
                }
                Student student;
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                if (index == -1)
                {
                    student = null;
                }
                else
                {
                    student = Student.AllStudents[index];
                }

                Console.WriteLine("Welke cursus?");
                Console.WriteLine("0. null");
                for (int i = 0; i < Course.AllCourses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {Course.AllCourses[i].Title}");
                }
                Course course;
                index = Convert.ToInt32(Console.ReadLine()) - 1;
                if (index == -1)
                {
                    course = null;
                }
                else
                {
                    course = Course.AllCourses[index];
                }

                byte? result = null;
                Console.WriteLine("Wil je een resultaat toekennen?");
                if (Console.ReadLine().ToLower().Trim() == "ja")
                {
                    Console.WriteLine("Wat is het resultaat?");
                    result = Convert.ToByte(Console.ReadLine());
                }
                try
                {
                    new CourseRegistration(student, course, result);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (CapacityExceededException coex)
                {
                    Console.WriteLine(coex.Message);
                }
            }
        }
        public static void ShowCourseRegistrations()
        {
            foreach (var item in CourseRegistration.AllCourseRegistrations)
            {
                Console.WriteLine($"{item.Student.Name} ingeschreven voor {item.Course.Title}");
            }
        }
        public static void ShowStudents()
        {
            foreach (var item in Student.AllStudents)
            {
                Console.WriteLine(item);
            }
        }

        public static void ShowCourses()
        {
            IComparer<Course> comparer = new CoursesByTitle();
            
            var sorted = Course.AllCourses.Sort(comparer);
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }
        public static void Export()
        {
            List<ICSVSerializable> allData = new List<ICSVSerializable>();
            foreach (var item in Course.AllCourses)
            {
                allData.Add(item);
            }
            foreach (var item in Person.AllPersons)
            {
                allData.Add(item);
            }
            string output = "";
            foreach (var item in allData)
            {
                Console.WriteLine(item.ToCSV());
                output += item.ToCSV() + "\n";
            }
            File.WriteAllText("c:\\users\\ann\\documents\\SchoolAdminData.csv", output);

        }

    }
}

