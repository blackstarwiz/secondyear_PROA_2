namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studenten = new List<Student>();
            bool addStudent = true;
           
            do
            {
                int add;
                Console.Write("Toevoegen van student 1:ja 2:nee");

                add = Convert.ToInt32(Console.ReadLine());

                if(add == 1) {
                    Student newStudent = new Student();

                    Console.Write("Voer naam in: ");
                    newStudent.Naam = Console.ReadLine();

                    Console.WriteLine("Geef geboorte datum:");
                    Console.Write("Jaar:");
                    int jaar = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Maand: ");
                    int maand = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Dag: ");
                    int dag = Convert.ToInt32(Console.ReadLine());
                    newStudent.GeboorteDatum = new DateTime(jaar, maand, dag);

                    newStudent.StudentenNummer += 1;

                    Console.Write("Voer Cursussen in vb 'OO Programmeren,Cloud Systems': ");
                    newStudent.Cursussen = Console.ReadLine().Split(",");
                }
                else
                {
                    addStudent = false;
                }

            } while (addStudent);

            if(studenten.Count > 0)
            {
                foreach (Student student in studenten)
                {
                    Console.WriteLine(student.toonInfo());
                }
            }
            else
            {
                Console.WriteLine("Er Zijn geen studenten toegevoegd");
            }
            
        }
    }
}
