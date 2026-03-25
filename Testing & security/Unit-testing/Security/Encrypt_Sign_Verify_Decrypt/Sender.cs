using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Sign_Verify_Decrypt
{
    public class Sender
    {
        //basis pad naar project map
        private string _projectPath = "";

        //basis pad naar binn/Debug/net map
        private string _netPath = "";

        public Sender()
        {
            //zoek bij construct de project path en bin/Debug/net path
            _projectPath = ProjectPathFinder();
            _netPath = NetPathFinder(_projectPath);
        }

        public string ProjectPath
        {
            get
            {
                return _projectPath;
            }
        }

        public string NetPath
        {
            get
            {
                return _netPath;
            }
        }

        public void AESEncryptor(string plainText)
        {
            Aes aes = Aes.Create();
            aes.GenerateKey();
            aes.GenerateIV();

            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encrypted;

            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                encrypted = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
            }

            File.WriteAllBytes("secret.enc", encrypted);
            File.WriteAllBytes("secret.enc.key", aes.Key);
            File.WriteAllBytes("secret.enc.iv", aes.IV);

            HashData(encrypted);
        }

        public void HashData(byte[] encrypted)
        {
            byte[] hashBytes = SHA256.HashData(encrypted);
            string base64Hash = Convert.ToBase64String(hashBytes);

            File.WriteAllText("secret.enc.pubkey", "KEY-1");
            File.WriteAllText("secret.enc.sig", "KEY-1:" + base64Hash);
        }

        private string ProjectPathFinder()
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

            return startDirectory ?? "";
        }

        public string NetPathFinder(string projectPath)
        {
            var netMappen = Directory.EnumerateDirectories(projectPath, "net*", SearchOption.AllDirectories);
            string _netPath = "";
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

        public void CreateSecretTextFile(string plainText)
        {
            File.WriteAllText("secret.txt", plainText);
        }
    }
}