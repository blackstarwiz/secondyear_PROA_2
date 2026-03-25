using System.Diagnostics;

namespace UnitTestingDependencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Speler");

            Console.WriteLine("Dit is de Numbers Game");
            Console.WriteLine("Je zal een number ingeven,");
            Console.WriteLine("deze wordt dat vergeleken met de dobbelsteen");
            Console.WriteLine();
            Console.WriteLine("Voer een getal in:");

            if(!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Ingevoerde waarde is van type string");
                Environment.Exit(0);
            }

            NumberGame game = new NumberGame(new Die());

            int score = game.RateGuess(guess);
            Console.WriteLine("score: {0}", score);
        }
    }
}
