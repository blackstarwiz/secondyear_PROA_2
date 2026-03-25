namespace Digitale_handtekening_maken__dummy_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Digitale_handtekening signature = new Digitale_handtekening(); ;
            
            Program project = new Program();
            //Vindt project filepath
            string projectPath = signature.ProjectPath();
            //Vindt net map in bin/bug/netx.x
            string netPath = signature.NetPath(projectPath);

            //vraag gebruiker voor input
            Console.WriteLine("Welk bericht wil je hashen en handtekenen");
            Console.Write("Voer iets in: ");
            string plaintext = Console.ReadLine() ?? "";

            //maak netPath/secret.txt
            string secretTextPath = Path.Combine(netPath, "secret.txt");
            //maak bestand .txt als deze nog niet bestaat ander overwrite deze de oude versie
            signature.CreateFile(secretTextPath, plaintext);

            //bereken de hash van secret.txt
            string base64Hash = signature.CalculateHash(secretTextPath);
            string base64Signature = "KEY-1:" + base64Hash; 

            //maak bestand van secret.txt naar secret.txt.sig
            string sigFilePath = Path.Combine(netPath, "secret.txt.sig");
            //maak een bestand dat .sig zal bevatten
            signature.CreateSigFile(base64Signature, sigFilePath);


            //maak path naar bestand
            string pubKeyFilePath = Path.Combine(netPath, "secret.txt.pubkey");
            //maak public key 
            signature.CreatePublicKey(pubKeyFilePath,"KEY-1");

            //nakijken of alle bestand bestaan
            if (File.Exists(secretTextPath) & File.Exists(sigFilePath) & File.Exists(pubKeyFilePath))
            {
                Console.WriteLine("Alle bestand bestaan");
                var textFiles = Directory.EnumerateFiles(netPath, "*.txt*");
                
                foreach(string file in textFiles)
                {
                    Console.WriteLine(file);
                }
            
            }
            else
            {
                Console.WriteLine("niet alle bestanden zijn gemaakt, bekijk de map bin/bug/net");
            }


                Console.ReadKey();
        }

        
    }
}