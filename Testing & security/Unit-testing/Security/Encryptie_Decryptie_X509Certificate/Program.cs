using System.Security.Cryptography.X509Certificates;

namespace Encryptie_Decryptie_X509Certificate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
