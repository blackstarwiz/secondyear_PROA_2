using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Sign_Verify_Decrypt
{
    internal class Reciever
    {
        private readonly string _pubkey;
        private readonly string _sig;
        private readonly byte[] _encryptedBestand;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public Reciever()
        {
            //start betanden al toevoegen aan ontvanger klasse demo
            _pubkey = File.ReadAllText("secret.enc.pubkey");
            _sig = File.ReadAllText("secret.enc.sig");
            _encryptedBestand = File.ReadAllBytes("secret.enc");
            _key = File.ReadAllBytes("secret.enc.key");
            _iv = File.ReadAllBytes("secret.enc.iv");
        }

        public void Dehashing()
        {
            //nakijken of pubkey en sig de atributen KEY-1 en KEY-1: bevatten
            if (_pubkey.StartsWith("KEY-1") && _sig.StartsWith("KEY-1:"))
            {
                //maak string array met spilt voor parts
                string[] parts = _sig.Split(":");
                //we nemen [1] want deze bevaat de hash die we gaan vergelijken
                string hashUitSignature = parts[1];

                //we maken een nieuwe hash van de plaintext bestand  _encyptedBestand
                byte[] nieuweHashBytes = SHA256.HashData(_encryptedBestand);
                //we zetten nieuweHashBytes om naar leesbare string met behulp van Convert.ToBase64String
                string nieuweBase64Hash = Convert.ToBase64String(nieuweHashBytes);

                //we vergelijken nu de twee verschillende base64hash string's om te zien of deze nog gelijk zijn
                if (hashUitSignature == nieuweBase64Hash)
                {
                    //als hashes gelijk zijn gaan we decrypteren
                    Console.WriteLine("Hashes zijn gelijk, Bestand decrypten....");
                    AESDecryptor();
                }
                else
                {
                    throw new Exception("Bestand is gewijzigd!!");
                }
            }
        }

        public void AESDecryptor()
        {
            //
            using (Aes decryptAes = Aes.Create())
            {
                decryptAes.Key = _key;
                decryptAes.IV = _iv;

                using (ICryptoTransform decryptor = decryptAes.CreateDecryptor())
                {
                    byte[] decrypted = decryptor.TransformFinalBlock(_encryptedBestand, 0, _encryptedBestand.Length);
                    string decryptedText = Encoding.UTF8.GetString(decrypted);
                    File.WriteAllText("secret.decrypted.txt", decryptedText);
                    Console.WriteLine("Bestand gedecrypteerd: " + decryptedText);
                }
            }
        }
    }
}