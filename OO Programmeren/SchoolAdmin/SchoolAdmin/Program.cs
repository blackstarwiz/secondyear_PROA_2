namespace SchoolAdmin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            List<Student> studenten = new List<Student>();
            Student student1 = new Student();
            Student student2 = new Student();


            student1.Naam = "Said Aziz";
            student1.GeboorteDatum = new DateTime(2000,6,1);
            student1.StudentNumber = Student.StudentenTeller;

            Student.StudentenTeller++;

            student1.RegistreerVoorCursus("OOP");
            student1.RegistreerVoorCursus("CloudSystem");
            student1.RegistreerVoorCursus("WPL");

            student2.Naam = "Mieke Vermeulen";
            student2.GeboorteDatum = new DateTime(1998,1,1);
            student2.StudentNumber = Student.StudentenTeller;

            Student.StudentenTeller++;

            student2.RegistreerVoorCursus("OOP");
            student2.RegistreerVoorCursus("CloudSystem");
            student2.RegistreerVoorCursus("WPL");

            studenten.Add(student1);
            studenten.Add(student2);

            string[] optie = ["DemonstreerStudenten uitvoeren", "DemostreerCursussen uitvoeren"];

            Console.WriteLine("Wat wil je doen?");
            for(int i = 0; i < optie.Length; i++)
            {
                Console.WriteLine($"{i+1}: {optie[i]}");
            }

            Console.Write("> ");
            int keuze = Convert.ToInt32(Console.ReadLine());

            switch (keuze)
            {
                case 1:
                    for(int i = 0; i < studenten.Count; i++)
                    {
                        Console.WriteLine($"{studenten[i].GenereerNaamKaartje()}\n{studenten[i].BerkenWerkLading()}");
                    }
                    break;
                case 2:
                    Program.DemoCourses();
                    break;
            }

            Console.ReadKey();
        }
        public static void DemoCourses()
        {
            List<Student> studenten = new List<Student>();
            Student student1 = new Student();
            Student student2 = new Student();


            student1.Naam = "Said Aziz";
            student1.GeboorteDatum = new DateTime(2000, 6, 1);
            student1.StudentNumber = Student.StudentenTeller;

            Student.StudentenTeller++;

            student1.RegistreerVoorCursus("OOP");
            student1.RegistreerVoorCursus("CloudSystem");
            student1.RegistreerVoorCursus("WPL");

            student2.Naam = "Mieke Vermeulen";
            student2.GeboorteDatum = new DateTime(1998, 1, 1);
            student2.StudentNumber = Student.StudentenTeller;

            Student.StudentenTeller++;

            student2.RegistreerVoorCursus("OOP");
            student2.RegistreerVoorCursus("CloudSystem");
            student2.RegistreerVoorCursus("WPL");

            studenten.Add(student1);
            studenten.Add(student2);

            Course newcourse = new Course();

            newcourse.Students = studenten;
            newcourse.Title = "Webtechnologie";
            newcourse.ShowOverview();
        }
    }
}