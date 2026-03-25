//nuget package toevoegen eerst zoek deze eerste using toe aan zoekbalk bij package manager nuget
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Encryptie_Decryptie_X509Certificate
{
    public class Program
    {
        static void Main(string[] args)
        {
            //laad certificate van .pem bestanden //create certificate van pem files
            X509Certificate2 cert = X509Certificate2.CreateFromPemFile("cert.pem", "key.pem");

            Console.WriteLine("Voer iets in:");
            Console.Write("> ");
            //vraag gebruiker voor een input
            string plaintext = Console.ReadLine() ?? "iets dat leesbaar is";

            Console.WriteLine("stap 1: Encryptie van plain text");
            byte[] ecnryptedPlaintext = EncryptWithCms(plaintext, cert);
            Console.WriteLine("Binaire data (Base64) > {0}", Convert.ToBase64String(ecnryptedPlaintext));

            //decryptie van encryptedPlaintext
            Console.WriteLine("stap 2: Decryptie van Encrypted plaintext");
            Console.WriteLine("Decrypted plaintext: {0}", DecryptWithCms(ecnryptedPlaintext, cert));
            Console.ReadKey();
        }


        public static byte[] EncryptWithCms(string plainText, X509Certificate2 recipientCert)
        {
            //haal de byte op van de ingevoerde plaintext met encoding format(utf8) met methode getbytes dat voor elke letter/symbol naar byte
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
            //maak een instantie van contactinfo en gebruik de default OID (object identifier) content type
            ContentInfo contentInfo = new ContentInfo(dataToEncrypt);
            //initialiseren van een instantie vaan de klasse met de contentinfo instantie specifieke content info
            EnvelopedCms cms = new EnvelopedCms(contentInfo);
            //maak een instantie van de ontvanger (recipient) met recipient identifier type, specifieke certificate
            CmsRecipient recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, recipientCert);

            //gebruik EnvelopedCms klasse om methode Encrypt(reciepient)
            //aan te roepen om het bericht te vergendelen voor een specifieke ontvanger
            cms.Encrypt(recipient);

            //het terug sturen van de bytesarray
            return cms.Encode(); // Versleuteld CMS-bericht
        }

        public static string DecryptWithCms(byte[] encryptedData, X509Certificate2 certWithPrivateKey)
        {
            //maak een instatie van EnvolpedCms default constructor
            EnvelopedCms cms = new EnvelopedCms();
            //gebruik de methode Decode uit klasse EnvelopedCms om bytes array te decoderen
            cms.Decode(encryptedData);
            //gebruikt methode Decrypt(certificateCollection(certificate)) om het bericht te decypteren naar een 
            cms.Decrypt(new X509Certificate2Collection(certWithPrivateKey));
            return Encoding.UTF8.GetString(cms.ContentInfo.Content);
        }
    }
}
