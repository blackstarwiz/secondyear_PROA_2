using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace inloggen_encrypted_wachtwoord
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AdminAccount userAdmin = new AdminAccount();

            //vraag gebruikers naam
            Console.WriteLine("Voer gebruikersnaam in:");
            Console.Write("Gebruikernaam > ");
            string gebruikersnaam = Console.ReadLine() ?? "";

            //vraag wachtwoord
            Console.WriteLine("Voer Wachtwoord in:");
            Console.Write("Wachtwoord > ");
            string wachtwoord = Console.ReadLine() ?? "";

            //decrypte opgeslagen wachtwoord van admin
            string decryptedWachtwoord = userAdmin.DecryptedWachtwoord;

            if (gebruikersnaam == userAdmin.PlainTextGebruikersnaam & wachtwoord == decryptedWachtwoord)
            {
                Console.WriteLine("Inloggen gelukt");
                userAdmin.WelcomeMessage();
            }
            else
            {
                Console.WriteLine("Inloggen mislukt");
            }

            Console.WriteLine("\nDruk op Enter om af te sluiten...");
            Console.ReadKey();
        }

        public static byte[] EncryptWithCms(string plainText, X509Certificate2 recipientCert)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            ContentInfo contentInfo = new ContentInfo(dataToEncrypt);
            EnvelopedCms cms = new EnvelopedCms(contentInfo);
            CmsRecipient recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, recipientCert);
            cms.Encrypt(recipient);
            return cms.Encode(); // Versleuteld CMS-bericht
        }

        public static string DecryptWithCms(byte[] encryptedData, X509Certificate2 certWithPrivateKey)
        {
            EnvelopedCms cms = new EnvelopedCms();
            cms.Decode(encryptedData);
            cms.Decrypt(new X509Certificate2Collection(certWithPrivateKey));
            return Encoding.UTF8.GetString(cms.ContentInfo.Content);
        }

        public class AdminAccount
        {
            private readonly X509Certificate2 cert = X509Certificate2.CreateFromPemFile("cert.pem", "key.pem");

            private string wachtwoord = "admin";
            private string gebruikersnaam = "admin";
            private int pogingen = 0;

            private string PlainTextWachtwoord
            {
                get
                {
                    return wachtwoord;
                }
            }

            public string PlainTextGebruikersnaam
            {
                get
                {
                    return gebruikersnaam;
                }
            }

            public byte[] EncryptedWachtwoord
            {
                get
                {
                    return EncryptWithCms(PlainTextWachtwoord, cert);
                }
            }

            public string DecryptedWachtwoord
            {
                get
                {
                    return DecryptWithCms(EncryptedWachtwoord, cert);
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
            }
        }
    }
}