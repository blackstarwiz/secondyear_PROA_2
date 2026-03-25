using System.Timers;
using Timer = System.Timers.Timer;
namespace _2FA_met_tijdslimiet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            while (active)
            {
                try
                {
                    Console.Clear();
                    //Voer je gebruikers gegevens in
                    Console.WriteLine("Voer gebruikers naam in");
                    Console.Write("> ");
                    string username = Console.ReadLine() ?? "";

                    Console.WriteLine("Voer wachtwoord naam in");
                    Console.Write("> ");
                    string password = Console.ReadLine() ?? "";


                    //bevestig wachtwoord (maakt niet uit alles telt bij deze test)
                    //login creeren
                    Login newUser = new Login(username, password);

                    //check de 2FA
                    newUser.Verify2FA();

                    active = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Druk op een toets om opnieuw te proberen...");
                    Console.ReadKey();
                }
            }
        }


        public class Login
        {
            private Random rand = new Random();
            private DateTime _generationTime;
            private Timer _timer;
            
            private string _username = "";
            private string _password = "";

            private string twoFactoryPass = "";

            public Login(string username, string password)
            {
                _username = username;//"admin"
                _password = password;//"admin

                //init de timer
                _timer = new Timer(10000);//"timer van 10 seconden"
                //_timer.Elapsed += OnTimerElapsed;//"als de tijd verlopen is spreek deze functie aan"
                _timer.AutoReset = true;

                GenerateTOTP();//Genereer code

                ///_timer.Start();//start de timer
            }

            public string Username
            {
                get
                {
                    return _username;
                }
            }

            public string Password
            {
                get
                {
                    return _password;
                }
            }

            public string TwoFactoryPass
            {
                get
                {
                    return twoFactoryPass;
                }
            }

            private void GenerateTOTP()
            {
                _generationTime = DateTime.UtcNow;//vang tijd op
                twoFactoryPass = "";

                for (int i = 0; i < 6; i++)
                {
                    twoFactoryPass += rand.Next(10).ToString();
                }

                Console.WriteLine("Nieuwe code gegenereerd: " + twoFactoryPass);//Toon code in console
            }

            private void OnTimerElapsed(object sender, ElapsedEventArgs e) 
            { 
                GenerateTOTP(); 
            }

            public void Verify2FA()//als code is ingevoerd checken of deze code gelijk is
            {
                Console.WriteLine("Voer je 2FA in:");
                Console.Write("> ");

                string user2fa = Console.ReadLine() ?? "";
                //bereken het verschil 
                TimeSpan elapsed = DateTime.UtcNow - _generationTime;

                //nakijken dat het binnen de tijd is
                if (elapsed.TotalSeconds > 30)
                    throw new Exception("Code is verlopen!");

                //nakijken of de ingevoerde code gelijk is aan de genereerde code is
                //als deze niet juist is dan throw error
                if (twoFactoryPass != user2fa)
                    throw new ArgumentException("2FA is niet gelijk, u wordt uitgelogd!!");

                //Bij success stoppen we de timer om te voorkomen daat deze blijft gaan
                _timer.Stop();
                _timer.Dispose();

                Console.Clear();
                Console.WriteLine($"Welcome {Username.ToUpper()}!!");
                Console.ReadKey();
            }
        }
    }
}
