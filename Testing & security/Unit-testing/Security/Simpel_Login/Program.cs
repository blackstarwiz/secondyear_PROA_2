namespace Simpel_Login
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool active = true;
            Account user = new Account();

            do
            {
                Console.Clear();

                Console.WriteLine($"Login poging {user.Pogingen}");

                Console.WriteLine("Voer gebruikersnaam in:");
                Console.Write("Gebruikernaam > ");
                string gebruikersnaam = Console.ReadLine() ?? "";

                Console.WriteLine("Voer Wachtwoord in:");
                Console.Write("Wachtwoord > ");
                string wachtwoord = Console.ReadLine() ?? "";

                if (user.JuisteGeruikersNaam == gebruikersnaam && user.JuistWachtwoord == wachtwoord)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Inloggen gelukt!!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inloggen mislukt!");
                    Console.ResetColor();
                }
                //pauzeer de terminal om te kunnen lezen
                Thread.Sleep(TimeSpan.FromSeconds(1));
            } while (active);
        }
    }

    public class Account
    {
        private string juistWachtwoord = "admin";
        private string juisteGebruikersnaam = "admin";
        private int pogingen = 0;

        public string JuistWachtwoord
        {
            get
            {
                return juistWachtwoord;
            }
        }

        public string JuisteGeruikersNaam
        {
            get
            {
                return juisteGebruikersnaam;
            }
        }

        public int Pogingen
        {
            get
            {
                return pogingen;
            }
            set
            {
                pogingen = value;
            }
        }
    }
}