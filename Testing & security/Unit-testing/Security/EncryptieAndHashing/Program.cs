using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace EncryptieAndHashing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                bool active = true;
                string[] Options = ["Hash een wachtwoord", "Encryptie en decryptie met X509Certificate"];

                do
                {
                    Console.Clear();

                    Console.WriteLine("Kies optie");
                    Console.WriteLine("0: Stop");
                    for (int i = 0; i < Options.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}: {Options[i]}");
                    }

                    Console.Write("> ");
                    int optionChoice = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (optionChoice)
                    {
                        case 1:
                            Console.WriteLine("Voer een wachtwoord in");
                            string wachtwoord = Console.ReadLine() ?? "";

                            Console.WriteLine("Gehashed wachtwoord: {0}", HashString(wachtwoord));
                            break;
                        case 2:
                            string pfxPath = @"Certificates\DemoCert.pfx";
                            string password = "P@ssw0rd123";

                            var cert = new X509Certificate2(pfxPath, password);

                            Console.WriteLine("Certificaat succesvol geladen!");
                            Console.WriteLine($"Subject: {cert.Subject}");
                            Console.WriteLine($"Has Private Key: {cert.HasPrivateKey}");
                            Console.WriteLine($"Thumbprint: {cert.Thumbprint}");

                            break;
                        default:
                            active = false;
                            break;
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                } while (active);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string HashString(string _input = "")
        {
            {
                string hash = string.Empty;

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_input));
                    hash = Convert.ToBase64String(bytes);
                }
                return hash;
            }
        }
       
        public static byte[] EncryptWithCms(string plainText, X509Certificate2 recipientCert) 
        {
            return [];
        }

        public static string DecryptWithCms(byte[] encryptedData, X509Certificate2 certWithPrivateKey) 
        {
            return "";
        }
    }
}