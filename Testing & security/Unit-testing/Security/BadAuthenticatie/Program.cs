using System.ComponentModel.Design;
using System.Threading;

namespace BadAuthenticatie
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool active = true;
            Account user = new Account();

            do
            {
                if (user.Pogingen != 3)
                {
                    Console.Clear();
                    
                    //poging toevoegen om te weeten hoevaak de gebruiker probeert
                    user.Pogingen++;

                    Console.WriteLine($"Login poging {user.Pogingen}");

                    Console.WriteLine("Voer gebruikersnaam in:");
                    Console.Write("Gebruikernaam > ");
                    string gebruikersnaam = Console.ReadLine() ?? "";

                    Console.WriteLine("Voer Wachtwoord in:");
                    Console.Write("Wachtwoord > ");
                    string wachtwoord = Console.ReadLine() ?? "";

                    if(user.JuisteGeruikersNaam == gebruikersnaam && user.JuistWachtwoord == wachtwoord)
                    {
                        Console.WriteLine("Inloggen gelukt!!");
                    }
                    else
                    {
                        if(user.Pogingen == 3) { 
                            Console.WriteLine("Account is geblokeerd");
                            active = false;
                        }
                        else
                        {
                            Console.WriteLine("Probeer opnieuw");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Account is geblokkeerd");
                    active = false;
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