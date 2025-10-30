using System.Threading.Channels;

namespace SchoolAdmin
{
    internal class Program
    {
        private Random rnd = new Random();

        private string[] classes = ["Communicatie", "Programmeren", "Webtechnolgie", "Databanken"];

        private List<Student> students = new List<Student>();

        private static void Main(string[] args)
        {
            // Variabele die bepaalt of het hoofdmenu actief blijft draaien
            bool active = true;

            // Menu-opties die de gebruiker kan kiezen
            string[] optie = ["DemonstreerStudenten uitvoeren", "DemostreerCursussen uitvoeren", "ReadTextFormatStudent", "DemoStudyProgram", "DemoAdministrativePersonnel","DemoLecturers", "Terminating"];

            do
            {
                Console.Clear();
                int keuze = 0;
                Console.WriteLine("Wat wil je doen?");

                // Print de menu-opties op het scherm
                for (int i = 0; i < optie.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {optie[i]}");
                }

                Console.Write("> ");
                try
                {
                    keuze = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                switch (keuze)
                {
                    case 0:
                        Console.ReadKey();
                        break;

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
                        DemoStudyProgram();
                        break;

                    case 5:
                        DemoAdministrativePersonnel();
                        break;
                    case 6:
                        DemoLecturers();
                        break;

                    default:
                        Console.WriteLine("Terminating, press Enter");
                        Console.Write("> ");
                        Console.ReadKey();
                        active = false;
                        break;
                }
            } while (active);
        }

        public static void DemoStudents()
        {
            Program opt = new Program();

            Student student1 = new Student("Said Aziz", new DateTime(2000, 6, 1));
            Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));

            for (int i = 0; i < 3; i++)
            {
                byte? result;
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                Course courseName = new Course(opt.classes[randomClass]);
                byte check = (byte)(opt.rnd.Next(0, 21));

                if (check == 0)
                {
                    result = null;
                }
                else
                {
                    result = check;
                }

                student1.RegisterCourseResult(courseName, result);
            }

            for (int i = 0; i < 3; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                Course courseName = new Course(opt.classes[randomClass]);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student2.RegisterCourseResult(courseName, result);
            }

            student1.ShowOverview();
            student2.ShowOverview();

            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }

        public static void DemoCourses()
        {
            //object program maken voor de array en random te gebruiken binnen alle methodes
            Program opt = new Program();

            //student objecten maken
            Student student1 = new Student("Said Aziz", new DateTime(2000, 6, 1));

            Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));

            //student objecten tovoegen aan de list students
            opt.students.Add(student1);
            opt.students.Add(student2);

            //Course object aanmaken en studenten toevoegen plus studiepunten
            Course webCourse = new Course("Webtechnologie", opt.students, 6);

            Course oopCourse = new Course("OO Programmeren", opt.students);

            Course wplCours = new Course("WPL");

            try
            {
                webCourse.ShowOverview();
                oopCourse.ShowOverview();
                wplCours.ShowOverview();

                //Course idResult = Course.SearchCourseById(3);
                //Console.WriteLine(idResult.Title);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }

        public static void ReadTextFormatStudent()
        {
            Program opt = new Program();

            Console.Clear();
            //csv bestand vragen
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            Console.Write(">");
            string csvString = Console.ReadLine();

            //string omzetten naar array
            string[] csvArray = csvString.Split(";");

            //student aanmaken met indexen van de csv
            Student csvStudent = new Student(csvArray[0].ToString(), new DateTime(Convert.ToInt32(csvArray[3]), Convert.ToInt32(csvArray[2]), Convert.ToInt32(csvArray[1])));

            //student toevoegen aan de list object students
            opt.students.Add(csvStudent);
            //door de array gaan om de vakken en punten te vinden
            for (int i = 4; i < csvArray.Length; i += 2)
            {
                //als het geen string is gaan we SearchCourseById() gebruiken om de student toetevoegen aan het juist vak
                if (int.TryParse(csvArray[i], out int search))
                {
                    //maak course objecten aan
                    Course natuurkundeCourse = new Course("Natuurkunde", null, 9);
                    Course wiskundeCourse = new Course("Wiskunde");
                    Course scheiCourse = new Course("Scheikunde", null, 12);

                    csvStudent.RegisterCourseResult(Course.SearchCourseById(search), Convert.ToByte(csvArray[i + 1]));
                }
                else
                {
                    string randomClass = csvArray[i];
                    Course courseName = new Course(randomClass);

                    csvStudent.RegisterCourseResult(courseName, Convert.ToByte(csvArray[i + 1]));

                    Course wplCours = new Course("WPL");
                }
            }

            try
            {
                csvStudent.ShowOverview();
                Console.WriteLine("Student toegevoegd, terug naar menu");
                Console.Write("> ");
                Console.ReadKey();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DemoStudyProgram()
        {
            //Course communicatie = new Course("Communicatie");
            //Course programmeren = new Course("Programmeren");
            //Course databanken = new Course("Databanken");

            //List<Course> courses = new List<Course>() { communicatie, programmeren, databanken };

            //StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            //StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");

            //programmerenProgram.Courses = courses;
            //snbProgram.Courses = courses;

            //programmerenProgram.ShowOverview();
            //snbProgram.ShowOverview();

            //opleidingen maken van de verschillende  Course-objecten
            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");

            //list object maken van de verschillende richtingen waarvan de opleidngen meegegeven worden
            List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            List<Course> coursesSNB = new List<Course>() { communicatie, programmeren, databanken };

            //study programma maken die een title en list van opleidingen nodig heeft
            StudyProgram programmerenProgram = new StudyProgram("Programmeren", coursesProgrammeren);
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer", coursesSNB);
            // programmerenProgram.Courses = coursesProgrammeren;
            // snbProgram.Courses = coursesSNB;
            //we willen hieronder Databanken schrappen uit het programma SNB

            //dit doet niets meer sinds het aanpassen van de courses in studyprogram -> immutable
            snbProgram.Courses.Remove(databanken);
            //voor SNB wordt de titel van de cursus Programmeren veranderd naar "Scripting"
            snbProgram.Courses[1].Title = "Scripting";
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();

            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }

        public static void DemoAdministrativePersonnel()
        {
            Dictionary<string, byte> taskAhmed = new Dictionary<string, byte> {
                {"roostering", 10 },
                {"correspondentie", 10 },
                {"animatie", 10 }
            };
            AdministrativePersonnel ahem = new AdministrativePersonnel("Ahmed Azzaoui", new DateTime(1988, 02, 04), taskAhmed);
            ahem.Seniority = 4;

            foreach (var personnel in ahem.AllAdministrativePersonnel)
            {
                Console.WriteLine(personnel.GenerateNameCard());

                Console.WriteLine(personnel.CalculateSalary());
                Console.WriteLine(personnel.DetermineWorkload());
            }
            Console.WriteLine("dit waren al de collegas, terug naar menu");
            Console.Write("Press Enter > ");
            Console.ReadKey();
        }

        public static void DemoLecturers()
        {
            Lecturer lectoren;//all lectoren toevoegen met dit ==>list van maken is ook een optie maar niet gevraagd in opgave

            var courses_Anna = new Dictionary<string, byte>
            {
                {"Economie", 10 },
                {"Statistiek", 10 },
                { "Analytische meetkunde", 10}
            };

            var annaBolzano = new Lecturer("Anna Bolzano", new DateTime(1975, 06, 12), courses_Anna);

            annaBolzano.Seniority = 9;

            lectoren = annaBolzano;

            foreach(var lector in lectoren.AllLecturer)
            {
                Console.WriteLine(lector.GenerateNameCard());

                foreach (var course in lectoren.AllCourses)
                {
                    Console.WriteLine(course.Key.Title);
                }

                Console.WriteLine(lector.CalculateSalary());
                Console.WriteLine(lector.DetermineWorkload());
            }

            Console.WriteLine("alle lectoren zijn getoont, terug naar menu");
            Console.Write("press enter >");
            Console.ReadKey();
        }
    }
}