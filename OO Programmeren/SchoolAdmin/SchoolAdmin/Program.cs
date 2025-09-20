namespace SchoolAdmin
{
    internal class Program
    {
        private static void Main(string[] args)
        {


            Student student1 = new Student();

            student1.Naam = "jason meulemans";
            student1.GeboorteDatum = new DateTime(1997,10,27);
            student1.StudentenNummer = 123;
            student1.StudentenTeller = 1;

            student1.RegistreerVoorCursus("OOP");
            student1.RegistreerVoorCursus("CloudSystem");
            student1.RegistreerVoorCursus("WPL");

            
            Console.WriteLine($"{student1.Naam},{student1.GeboorteDatum.ToString("d")},{student1.StudentenNummer},{student1.StudentenTeller}");

            Console.WriteLine(student1.GenereerNaamKaartje());

            Console.WriteLine($"Dit is {student1.BepaalWerkBelasting()} per week cursus");


            Console.ReadKey();
        }
    }
}