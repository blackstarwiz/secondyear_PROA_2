namespace SchoolAdmin
{
    internal class Program
    {
        //test voor te zien nu alles gepushed wordt zonder problemen
        private Random rnd = new Random();

        private string[] classes = ["Communicatie", "Programmeren", "Webtechnolgie", "Databanken"];

        private static void Main(string[] args)
        {
            bool active = true;
            string[] optie = ["DemonstreerStudenten uitvoeren", "DemostreerCursussen uitvoeren", "ReadTextFormatStudent", "Terminating"];

            do
            {
                Console.Clear();
                Console.WriteLine("Wat wil je doen?");
                for (int i = 0; i < optie.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {optie[i]}");
                }

                Console.Write("> ");
                int keuze = Convert.ToInt32(Console.ReadLine());

                switch (keuze)
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

            List<Student> studenten = new List<Student>();
            Student student1 = new Student("Said Aziz", new DateTime(2000, 6, 1));
            Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));

            student1.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 0; i < 3; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student1.RegisterCourseResult(opt.classes[randomClass], result);
            }

            student2.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 0; i < 3; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student2.RegisterCourseResult(opt.classes[randomClass], result);
            }

            student1.ShowOverview();
            student2.ShowOverview();
        }

        public static void DemoCourses()
        {
            Program opt = new Program();

            List<Student> studenten = new List<Student>();
            Student student1 = new Student("Said Aziz", new DateTime(2000, 6, 1));
            Student student2 = new Student("Mieke Vermeulen", new DateTime(1998, 1, 1));

            Student.StudentCounter++;

            for (int i = 0; i > 2; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student1.RegisterCourseResult(opt.classes[randomClass], result);
            }

            Student.StudentCounter++;

            for (int i = 0; i > 2; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student2.RegisterCourseResult(opt.classes[randomClass], result);
            }

            studenten.Add(student1);
            studenten.Add(student2);

            Course webCourse = new Course("Webtechnologie", studenten, 6);
            Course oopCourse = new Course("OO Programmeren", studenten, 9);

            webCourse.ShowOverview();
            oopCourse.ShowOverview();
        }

        public static void ReadTextFormatStudent()
        {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat:");
            Console.Write(">");
            string csvString = Console.ReadLine();

            string[] csvArray = csvString.Split(";"); ;

            Student student3 = new Student(csvArray[0].ToString(), new DateTime(Convert.ToInt32(csvArray[3]), Convert.ToInt32(csvArray[2]), Convert.ToInt32(csvArray[1])));
            student3.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 4; i < csvArray.Length; i+=2)
            {
                string randomClass = csvArray[i];
                byte result = Convert.ToByte(csvArray[i + 1]);

                student3.RegisterCourseResult(randomClass, result);
            }

            student3.ShowOverview();
        }
    }
}