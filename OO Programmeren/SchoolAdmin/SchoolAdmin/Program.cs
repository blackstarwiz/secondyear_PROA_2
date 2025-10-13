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
            string[] optie = ["DemonstreerStudenten uitvoeren", "DemostreerCursussen uitvoeren", "ReadTextFormatStudent", "DemoStudyProgram", "Terminating"];

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

                    default:
                        Console.WriteLine("Terminating, press Enter");
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

            student1.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

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

            student2.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

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
            Student.StudentCounter++;

            Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));
            Student.StudentCounter++;
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

            //csv bestand vragen
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            Console.Write(">");
            string csvString = Console.ReadLine();

            //string omzetten naar array
            string[] csvArray = csvString.Split(";");

            //student aanmaken met indexen van de csv
            Student csvStudent = new Student(csvArray[0].ToString(), new DateTime(Convert.ToInt32(csvArray[3]), Convert.ToInt32(csvArray[2]), Convert.ToInt32(csvArray[1])));
            csvStudent.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;
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

            Course communicatie = new Course("Communicatie");
            Course programmeren = new Course("Programmeren");
            Course databanken = new Course("Databanken");
            List<Course> coursesProgrammeren = new List<Course>() { communicatie, programmeren, databanken };
            List<Course> coursesSNB = new List<Course>() { communicatie, programmeren, databanken };
            StudyProgram programmerenProgram = new StudyProgram("Programmeren");
            StudyProgram snbProgram = new StudyProgram("Systeem- en netwerkbeheer");
            programmerenProgram.Courses = coursesProgrammeren;
            snbProgram.Courses = coursesSNB;
            //we willen hieronder Databanken schrappen uit het programma SNB
            snbProgram.Courses.Remove(databanken);
            //voor SNB wordt de titel van de cursus Programmeren veranderd naar "Scripting"
            snbProgram.Courses[1].Title = "Scripting";
            programmerenProgram.ShowOverview();
            snbProgram.ShowOverview();

            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.Write(">");
            Console.ReadKey();
        }
    }
}