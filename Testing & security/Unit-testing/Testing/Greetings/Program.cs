namespace Greetings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateGetter currentDateObject = new DateGetter();//Object aanmaken dat current dayoftheweek implementeert

            Greeter calendar = new Greeter(currentDateObject);//Greeter object maken dat DateGetter mee krijgt

            Console.WriteLine(calendar.GetMessage());//Ga naar GetMessage voor info -->class Greeter
            Console.Write("Druk op Enter: ");
            Console.ReadKey();
        }
    }
}
