namespace Simple_Login_3Times
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
                    Console.WriteLine("Inloggen gelukt!!");
                    user.WelcomeMessage();
                    active = false;
                }
                else
                {
                    if (user.Pogingen == 3)
                    {
                        Console.WriteLine("Account is geblokeerd");
                        active = false;
                    }
                    else
                    {
                        Console.WriteLine("Probeer opnieuw");
                    }
                }

                //poging toevoegen om te weeten hoevaak de gebruiker probeert
                user.Pogingen++;

                //pauzeer de terminal om te kunnen lezen
                Thread.Sleep(TimeSpan.FromSeconds(1));
            } while (active);
        }
    }

    public class Account
    {
        private string wachtwoord = "admin";
        private string gebruikersnaam = "admin";
        private int pogingen = 0;

        public string JuistWachtwoord
        {
            get
            {
                return wachtwoord;
            }
        }

        public string JuisteGeruikersNaam
        {
            get
            {
                return gebruikersnaam;
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

        public void WelcomeMessage()
        {
            Console.WriteLine($"Welcome {gebruikersnaam}");
            //pauze
            Thread.Sleep(TimeSpan.FromSeconds(2));
            
        }
    }
}