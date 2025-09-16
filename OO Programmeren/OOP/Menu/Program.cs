using System.Security.Cryptography.X509Certificates;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] topic = ["DateTime"];
            int keuzeTopic = 0;

            Console.WriteLine("Menu Topic");
            for(int i = 0; i < topic.Length; i++)
            {
                Console.WriteLine($"{i+1}: ${topic[i]}");
            }

            keuzeTopic = Convert.ToInt32(Console.ReadLine());

            switch (keuzeTopic)
            {
                case 1:
                    Console.WriteLine("Er zijn nog geen Oefenigen voor deze topic");
                    Program.ToonSubMenu(keuzeTopic);
                    DateTimeOefeningen iets = new DateTimeOefeningen();

                    DateTimeOefeningen.toonIets();
                    break;
            };
            
        }
        static void ToonSubMenu(int topicNum)
        {
           
        }
    }
}
