namespace Encrypt_Sign_Verify_Decrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sender sender = new Sender();
           
            //Vraag gebruiker om een plaintext in te voeren
            Console.WriteLine("Verzender:");
            Console.WriteLine("Voer een text in:");
            Console.Write("> ");

            string textCreate = Console.ReadLine() ?? "";

            //maak een secret.txt bestaand met textCreate als waarde
            Console.WriteLine("Aanmaken van secret.txt");
            sender.CreateSecretTextFile(textCreate);

            //binnen de methode AESEncryptor maken we een key (Symetric Secret Key ) en iv (Initialization Vector)
            //plus hashen van de encrypted bestand
            sender.AESEncryptor(textCreate);
            Console.WriteLine("Bestanden zijn aangemakt");
            Console.WriteLine("Nu kan de ontvanger het bericht dehashen en decrypten");

            Console.WriteLine("Ontvanger:");
            Reciever reciever = new Reciever();

            reciever.Dehashing();
        }
    }
}
