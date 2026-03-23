using System.Security.Cryptography;
using System.Text;


namespace Hash_wachtwoord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voer een wachtwoord in");
            string wachtwoord = Console.ReadLine() ?? "";

            Console.WriteLine("Gehashed wachtwoord: {0}", HashString(wachtwoord)); 
        }


        public static string HashString(string _input)
        {
            string hash = string.Empty;

            //string (leesbaar door mens) => byte array 
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(_input));

            Console.Write("bytes array: ");
            foreach(var element in bytes)
            {
                Console.Write(element);
            }
            Console.WriteLine();
            //bytes array omvormen naar leestbare string
            hash = Convert.ToBase64String(bytes);

            return hash;
        }
    }
}
