namespace Digitale_handtekening
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string filePath = @"C:\Users\jason\OneDrive\Desktop\01-Programmeren-25-26\Testing & security\Unit-testing\les_2_two_facory_digi_handtekening\Digitale_handtekening\secret.txt";
            const string pubKey = "KEY-1";
            const string pubKeyFilePath = filePath + ".pubkey";
            const string sigPath = filePath + ".sig";

            Digital_signature sign = new Digital_signature();

            try
            {
                //txt bestand maken met content
                sign.CreateFile(filePath, "Dit is een geheim bericht!");
                //bereken de hash van de file
                string base64Hash = sign.CalculateHash(filePath);

                string signature = pubKey + ":" + base64Hash;
                
                //maak sig bestand
                sign.CreateSigFile(signature, sigPath);
                
                //maak public key bestand
                sign.CreatePublicKey(pubKey, pubKeyFilePath);
                

                if (File.Exists(filePath) && File.Exists(pubKeyFilePath) && File.Exists(sigPath))
                {
                    Console.WriteLine("Alle bestanden bestaan!");
                }
                else
                {
                    Console.WriteLine("Fout: Niet alle bestanden aangemaakt.");
                }

                //het nakijken daat de hash gelijk is
                sign.VerifySignature(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

   
}