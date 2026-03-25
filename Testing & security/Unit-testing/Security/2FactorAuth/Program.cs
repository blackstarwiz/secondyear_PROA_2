namespace _2FactorAuth
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool active = true;
            while (active)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("Voer gebruikers naam in");
                    Console.Write("> ");
                    string username = Console.ReadLine() ?? "";

                    Console.WriteLine("Voer wachtwoord naam in");
                    Console.Write("> ");
                    string password = Console.ReadLine() ?? "";

                    //login creeren
                    Login newUser = new Login(username, password);

                    //vragen aan gebruiker om 2fa
                    Console.WriteLine("2FA password:");
                    Console.WriteLine(newUser.TwoFactoryPass);

                    Console.WriteLine("Voer je 2FA in");
                    string user2fa = Console.ReadLine() ?? "";

                    newUser.Verify2FA(user2fa);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public class Login
        {
            private Random rand = new Random();

            private string _username = "";
            private string _password = "";

            private string twoFactoryPass = "";

            public Login(string username, string password)
            {
                _username = username;
                _password = password;

                _2FAPass();
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

            private string _2FAPass()
            {
                for (int i = 0; i < 6; i++)
                {
                    twoFactoryPass += rand.Next(11);
                }

                return twoFactoryPass;
            }

            public void Verify2FA(string user2fa)
            {
                if (twoFactoryPass != user2fa)
                    throw new ArgumentException("2 Factory is niet gelijk, u wordt uitgelogt!!");
                Console.Clear();
                Console.WriteLine($"Welcome {Username.ToUpper()}!!");
                Console.ReadKey();
            }
        }
    }
}
}
