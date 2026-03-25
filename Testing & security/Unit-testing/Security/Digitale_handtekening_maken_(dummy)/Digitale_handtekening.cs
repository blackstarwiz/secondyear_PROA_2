using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Digitale_handtekening_maken__dummy_
{
    public class Digitale_handtekening
    {
        private string _filePath { get; set; } = "";
        private string _netPath { get; set; } = "";

        public string ProjectPath()
        {
            string startDirectory = null;
            //find project file path
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            //check of parent niet null is
            if (projectPath != null)
            {
                var projectInfo = projectPath.Parent;
                if (projectInfo != null)
                {
                    startDirectory = projectInfo.FullName;
                }
                //Console.WriteLine("project map locatie: {0}", startDirectory);
            }

            return startDirectory;
        }

        public string NetPath(string projectPath)
        {
            var netMappen = Directory.EnumerateDirectories(projectPath, "net*", SearchOption.AllDirectories);

            foreach (string map in netMappen)
            {
                if (map.Contains("bin"))
                {
                    if (map.Contains("Debug"))
                    {
                        //Console.WriteLine(map);
                        _netPath = map;
                    }
                }
            }

            return _netPath;
        }

        public void CreateFile(string filepath, string content)
        {
            File.WriteAllText(filepath, content);
        }

        public string CalculateHash(string filepath)
        {
            string fileBytes = File.ReadAllText(filepath);
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(fileBytes));
            string base64Hash = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Hash: " + base64Hash);

            return base64Hash;
        }

        public void CreatePublicKey(string pubKeyPath, string pubKey)
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