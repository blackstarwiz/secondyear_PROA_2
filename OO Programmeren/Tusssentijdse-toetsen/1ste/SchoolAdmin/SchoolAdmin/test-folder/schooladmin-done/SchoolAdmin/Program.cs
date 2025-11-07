using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SchoolAdmin
{
    internal class Program
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
                Console.WriteLine("7. Demonstreer alumni uitvoering");
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
                        DemoAlumni();
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
            List<Student> saidAndMieke = new List<Student>();
            saidAndMieke.Add(said);
            saidAndMieke.Add(mieke);

            Course communicatie = new Course("Communicatie", saidAndMieke, 6);
            Course programmeren = new Course("Programmeren", saidAndMieke);
            Course webtechnologie = new Course("Webtechnologie");
            Course databanken = new Course("Databanken");

            webtechnologie.Students.Add(said);
            databanken.Students.Add(mieke);

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
            var taken = new Dictionary<string, byte>();
            taken.Add("roostering", 10);
            taken.Add("correspondentie", 10);
            taken.Add("animatie", 10);
            AdministrativePersonnel ahmed = new AdministrativePersonnel("Ahmed Azzaoui", new DateTime(1988, 2, 4), taken);
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

        public static void DemoAlumni()
        {
            Alumnus sofie = new Alumnus("Sofie De Smet",new DateTime(2002,01,01),2023);
            Alumnus karim = new Alumnus("Karim El Amrani",new DateTime(2003,04,02),2024);
            Alumnus lena = new Alumnus("Lena Van Gucht",new DateTime(2002,11,05),2022);

            sofie.UpdateCarreer("Dataflow","Software Engineer",WorkType.Constultant,2);
            lena.UpdateCarreer("Creatic","UX Design",WorkType.Loondienst,3);

            var taken = new Dictionary<string, byte>();
            taken.Add("Beldeiging", 8);

            Lecturer idris = new Lecturer("Idris Vermonden", new DateTime(1980, 02, 02), taken);


            idris.AddAlumnus(sofie);
            idris.AddAlumnus(karim);

            idris.AddAlumnus(karim);

            Console.WriteLine(idris.GuidedAlumni.ToString());

            foreach(var alumnis in Alumnus.AllAllumni)
            {
                alumnis.ToString();
            }
        }
    }
}
