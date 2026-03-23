using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Digitale_handtekening
{
    public class Digital_signature
    {
        public void CreateFile(string filepath, string content)
        {
            File.WriteAllText(filepath, content);
        }

        public string CalculateHash(string filepath)
        {
            string fileBytes = File.ReadAllText(filepath);
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(fileBytes));
            string base64Hash = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Hash: " + base64Hash);

            return base64Hash;
        }

        public void CreatePublicKey(string pubKey, string pubKeyPath)
        {
            File.WriteAllText(pubKeyPath, pubKey);
        }

        public void CreateSigFile(string signature, string sigPath)
        {
            File.WriteAllText(sigPath, signature);
        }

        public void VerifySignature(string filepath)
        {
            string sigPath = filepath + ".sig";
            string pubkeyPath = filepath + ".pubkey";

            //herbereken de hash van het huidige bestand
            string currentHash = CalculateHash(filepath);

            //lees opgeslagen signature
            string storedSignature = File.ReadAllText(sigPath);

            //splits ":" om de hash te lezen
            string[] parts = storedSignature.Split(":");
            string storedHash = parts[1];

            //vergelijk de file met de berekende hash

            if (currentHash == storedHash)
            {
                Console.WriteLine("Handtekening geldig! Bestand is niet gewijzigd");
            }
            else
            {
                Console.WriteLine("Handtekening ongeldig! Bestand is gewijzigd");
            }
        }
    }
}
