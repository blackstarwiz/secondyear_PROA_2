namespace SchoolAdmin
{
    internal class Program
    {
        private Random rnd = new Random();

        private string[] classes = ["Communicatie", "Programmeren", "Webtechnolgie", "Databanken"];

        private static async Task Main(string[] args)
        {
            // Variabele die bepaalt of het hoofdmenu actief blijft draaien
            bool active = true;

            // Menu-opties die de gebruiker kan kiezen
            string[] optie = ["DemonstreerStudenten", "DemostreerCursussen", "ReadTextFormatStudent", "DemoStudyProgram", "DemoAdministrativePersonnel", "DemoLecturers", "Student toevoegen", "Cursus Toevoegen", "VakInschrijving toevoegen", "Inschrijvingsgegevens tonen", "Studenten sorteren a -> z","Voorbeeld code Examen", "Terminating"];

            do
            {
                Console.Clear();
                Console.WriteLine("Wat wil je doen?");

                // Print de menu-opties op het scherm
                for (int i = 0; i < optie.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {optie[i]}");
                }

                Console.Write("> ");
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int keuze))
                        throw new ArgumentException("Voer geldige waarde in");

                    if (keuze > optie.Count())
                        throw new ArgumentOutOfRangeException("Optie bestaat niet");

                    switch (keuze)
                    {
                        case 1:
                            Student.DemoStudents();
                            break;

                        case 2:

                            Course.DemoCourses();
                            break;

                        case 3:
                            await ReadTextFormatStudent();
                            break;

                        case 4:

                            StudyProgram pro = new StudyProgram();
                            
                            pro.DemoStudyProgram();
                            break;

                        case 5:
                            DemoAdministrativePersonnel();
                            break;

                        case 6:
                            DemoLecturers();
                            break;

                        case 7:
                            Student.AddStudent();

                            break;
                        //addcourse
                        case 8:
                            Course.AddCourse();
                            break;

                        case 9:
                            CourseRegistration.AddCourseRegistration();
                            break;

                        case 10:
                            foreach (var student in CourseRegistration.AllCourseRegistrations)
                            {
                                if (student.Course is null)
                                    continue;
                                Console.WriteLine($"{student.Student.Name} ingescreven voor {student.Course.Title}");
                            }
                            Console.ReadKey();
                            break;

                        case 11:

                            Console.Clear();

                            var students = Person.AllPersons.OfType<Student>().ToList();

                            if (students.Count == 0)
                                throw new ArgumentNullException("Er zijn nog geen studenten toegevoeg: druk op 7");

                            //we geven de klasse mee die we willen gebruiken om de lijst spicifiek te sorteren
                            students.Sort(new StudentsAscendingByName());

                            //voor elke student in students
                            foreach (var student in students)
                            {
                                //tonen we de naam
                                Console.WriteLine($"{student.Id} - {student.Name}");
                            }
                            Console.WriteLine("Druk op Enter");
                            Console.Write("> ");
                            Console.ReadKey();
                            break;
                        case 12:
                            InternShipLecturer.Demo();
                            break;

                        default:
                            Console.WriteLine("Terminating, press Enter");
                            Console.Write("> ");
                            Console.ReadKey();
                            active = false;
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Druk op Enter");
                    Console.Write("> ");
                    Console.ReadKey();
                }
                catch (TyringToLeaveAPException e)
                {
                    Console.WriteLine($"{e.Message} probeert AP te verlaten");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Druk op Enter");
                    Console.Write("> ");
                    Console.ReadKey();
                }
            } while (active);
        }

        public static async Task ReadTextFormatStudent()
        {
            Console.Clear();
            //csv bestand vragen
            Console.WriteLine("Voer een absolute-path in van een .csv");
            Console.Write(">");

            using StreamReader reader = new(Console.ReadLine() ?? string.Empty);

            var text = await reader.ReadToEndAsync();
            if (text == "")
                throw new ArgumentException("Path kan niet leeg zijn");

            string[] csvArray = text.Split(";");
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