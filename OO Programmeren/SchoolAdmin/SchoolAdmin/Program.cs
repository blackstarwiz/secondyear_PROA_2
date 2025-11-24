namespace SchoolAdmin
{
    internal class Program
    {
        private Random rnd = new Random();

        private string[] classes = ["Communicatie", "Programmeren", "Webtechnolgie", "Databanken"];

        //private List<Student> students = new List<Student>();

        private static void Main(string[] args)
        {
            // Variabele die bepaalt of het hoofdmenu actief blijft draaien
            bool active = true;

            // Menu-opties die de gebruiker kan kiezen
            string[] optie = ["DemonstreerStudenten", "DemostreerCursussen", "ReadTextFormatStudent", "DemoStudyProgram", "DemoAdministrativePersonnel", "DemoLecturers", "Student toevoegen", "Cursus Toevoegen", "VakInschrijving toevoegen", "Inschrijvingsgegevens tonen", "Terminating"];

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

                    case 7:
                        try
                        {
                            Console.WriteLine("Naam van de student?");
                            Console.Write("> ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Geboortedatum van de student? (jaar/maand/dag)");
                            Console.Write("> ");
                            string date = Console.ReadLine();

                            if (date is null)
                                throw new NullReferenceException("Geen datum is ingevoerd");

                            DateTime birthDate = DateTime.Parse(date);

                            Student newstu = new Student(name, birthDate);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case 8:
                        Console.WriteLine("Titel van de cursus?");
                        Console.Write("> ");
                        string course = Console.ReadLine();

                        Console.WriteLine("Aantal studiepunten?");
                        Console.Write("> ");
                        byte points = Convert.ToByte(Console.ReadLine());

                        Course newCourse = new Course(course, points);
                        break;

                    case 9:
                        List<Student> studenten = new List<Student>();

                        Console.WriteLine("Welke student?");

                        for (int i = 0; i < Person.AllPersons.Count; i++)
                        {
                            if (Person.AllPersons[i] is Student)
                            {
                                Console.WriteLine($"{i + 1}: {Person.AllPersons[i].Name}");
                                studenten.Add((Student)Person.AllPersons[i]);
                            }
                        }

                        Console.Write("> ");
                        int choiceStudent = Convert.ToInt32(Console.ReadLine()) - 1;

                        for (int i = 0; i < Course.AllCourses.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} {Course.AllCourses[i].Title}");
                        }

                        Console.Write("> ");
                        int choiceCourse = Convert.ToInt32(Console.ReadLine()) - 1;

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

                        CourseRegistration newRegistration = new CourseRegistration(studenten[choiceStudent], Course.AllCourses[choiceCourse], result);
                        
                        break;

                    case 10:

                        foreach(var student in CourseRegistration.AllCourseRegistrations)
                        {
                            Console.WriteLine($"{student.Student.Name} ingescreven voor {student.Course.Title}");
                        }
                        Console.ReadKey();
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
            // opt.students.Add(student1);
            //opt.students.Add(student2);

            //Course object aanmaken en studenten toevoegen plus studiepunten
            Course webCourse = new Course("Webtechnologie", 6);

            Course oopCourse = new Course("OO Programmeren");

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
            // opt.students.Add(csvStudent);
            //door de array gaan om de vakken en punten te vinden
            for (int i = 4; i < csvArray.Length; i += 2)
            {
                //als het geen string is gaan we SearchCourseById() gebruiken om de student toetevoegen aan het juist vak
                if (int.TryParse(csvArray[i], out int search))
                {
                    //maak course objecten aan
                    Course natuurkundeCourse = new Course("Natuurkunde", 9);
                    Course wiskundeCourse = new Course("Wiskunde");
                    Course scheiCourse = new Course("Scheikunde", 12);

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
            //Maken van verschillende vak objecten
            Course commu = new Course("Communicatie");
            Course pro = new Course("Programmeren");
            Course data = new Course("Databanken");

            //Dictonary's voor de verschillende studyprograms
            Dictionary<Course, byte> programmerenCourses = new Dictionary<Course, byte>
            {
                {commu, 1},
                {pro, 1},
                {data, 1}
            };

            Dictionary<Course, byte> systemAndNetwork = new Dictionary<Course, byte>
            {
                {commu, 2},
                {pro, 1},
                {data, 1}
            };

            //Studyprogam objecten aanmaken
            StudyProgram programmeren = new StudyProgram("Programmeren", programmerenCourses);
            StudyProgram SNN = new StudyProgram("System and Network", systemAndNetwork);

            //tonen van de verschullende
            programmeren.ShowOverview();
            SNN.ShowOverview();

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
            AdministrativePersonnel person1 = new AdministrativePersonnel("Ahmed Azzaoui", new DateTime(1988, 02, 04), taskAhmed);
            person1.Seniority = 4;

            foreach (var personeel in Person.AllPersons)
            {
                if (personeel is AdministrativePersonnel admin)
                {
                    Console.WriteLine(admin.ToString());
                    Console.WriteLine(admin.DetermineWorkload());
                    Console.WriteLine(admin.CalculateSalary());
                }
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

            foreach (var lector in Person.AllPersons)
            {
                if (lector is Lecturer)
                {
                    Console.WriteLine(lector.GenerateNameCard());

                    foreach (var course in lectoren.AllCourses)
                    {
                        Console.WriteLine(course.Key.Title);
                    }

                    //Console.WriteLine(lector.CalculateSalary());
                    Console.WriteLine(lector.DetermineWorkload());
                }
            }

            Console.WriteLine("alle lectoren zijn getoont, terug naar menu");
            Console.Write("press enter >");
            Console.ReadKey();
        }
    }
}