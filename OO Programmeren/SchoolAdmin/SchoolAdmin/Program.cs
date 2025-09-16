namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();

            student1.Naam = "Said Aziz,";
            student1.GeboorteDatum = new DateTime(1997,10,27);
            student1.StudentenNummer = 01;
            student1.Cursussen = ["OOP", "CloudSystemen", "API ontwikkeling"];
            Student.StudentenTeller += 1;

            Console.WriteLine(student1.toonInfo());
        }
    }
}
