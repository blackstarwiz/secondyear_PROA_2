
namespace UnitTestingDependencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberGame = new NumberGame(new Die());
            var score = numberGame.RateGuess(5);
            Console.WriteLine($"Uw score: {score}");
            Console.Write("Druk op Enter: ");
            Console.ReadKey();

        }
    }
}
