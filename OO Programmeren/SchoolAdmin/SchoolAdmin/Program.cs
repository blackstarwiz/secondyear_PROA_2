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
            string[] optie = ["DemonstreerStudenten uitvoeren", "DemostreerCursussen uitvoeren", "Terminating"];

            do
            {
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
            Student student1 = new Student();
            Student student2 = new Student();

            student1.Name = "Said Aziz";
            student1.Birthdate = new DateTime(2000, 6, 1);
            student1.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 0; i < 3; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student1.RegisterCourseResult(opt.classes[randomClass], result);
            }

            
            //student1.RegistreerVoorCursus("OOP");
            //student1.RegistreerVoorCursus("CloudSystem");
            //student1.RegistreerVoorCursus("WPL");

            student2.Name = "Mieke Vermeulen";
            student2.Birthdate = new DateTime(1998, 1, 1);
            student2.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 0; i < 3; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student2.RegisterCourseResult(opt.classes[randomClass], result);
            }
            /*student2.RegistreerVoorCursus("OOP");
                         student2.RegistreerVoorCursus("CloudSystem");
                         student2.RegistreerVoorCursus("WPL");
                       */
            studenten.Add(student1);
            studenten.Add(student2);

            student1.ShowOverview();
            student2.ShowOverview();
        }

        public static void DemoCourses()
        {
            Program opt = new Program();

            List<Student> studenten = new List<Student>();
            Student student1 = new Student();
            Student student2 = new Student();

            student1.Name = "Said Aziz";
            student1.Birthdate = new DateTime(2000, 6, 1);
            student1.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 0; i > 2; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student1.RegisterCourseResult(opt.classes[randomClass], result);
            }
            //student1.RegistreerVoorCursus("OOP");
            //student1.RegistreerVoorCursus("CloudSystem");
            //student1.RegistreerVoorCursus("WPL");

            student2.Name = "Mieke Vermeulen";
            student2.Birthdate = new DateTime(1998, 1, 1);
            student2.StudentNumber = Student.StudentCounter;

            Student.StudentCounter++;

            for (int i = 0; i > 2; i++)
            {
                int randomClass = opt.rnd.Next(0, opt.classes.Length);
                byte result = (byte)(opt.rnd.Next(0, 21));

                student2.RegisterCourseResult(opt.classes[randomClass], result);
            }
            /*student2.RegistreerVoorCursus("OOP");
                         student2.RegistreerVoorCursus("CloudSystem");
                         student2.RegistreerVoorCursus("WPL");
                       */

            studenten.Add(student1);
            studenten.Add(student2);

            Course newcourse = new Course();

            newcourse.Students = studenten;
            newcourse.Title = "Webtechnologie";
            newcourse.ShowOverview();
        }
    }
}