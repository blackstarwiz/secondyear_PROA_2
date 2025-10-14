namespace Menu
{
    internal class Datastructuren
    {
        
        
        public static void PhoneBookNameNumber()
        {
            //we maken een key, value pair dat de naam en nummer zal bij hoiuden
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            //bool om de do while te laten werken tot als de gebruiker nee intypte
            bool activeUser = true;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Wil je (nog) een naam en nummer inlezen");
                Console.Write("> ");
                string awnser = Console.ReadLine();

                switch (awnser)
                {
                    case "ja":
                    case "Ja":
                    case "JA":
                    case "jA":

                        Console.Write("Naam >");
                        string name = Console.ReadLine();
                        Console.Write("Nummer >");
                        string number = Console.ReadLine();

                        //als naam al voorkomt in de phone boek vervangen we de nummer 
                        if (phoneBook.TryGetValue(name, out var result))
                        {
                            Console.WriteLine(result);
                            phoneBook[name] = number;
                        }
                        //anders voegen we de nieuwe entrie toe
                        else
                        {
                            phoneBook.Add(name, number);
                        }
                        ;
                        break;

                    default:
                        activeUser = false;
                        break;
                }

            } while (activeUser);
            ViewPhoneNameNumber(phoneBook);
        }

        public static void PhoneBookCityNameNumber()
        {
            //we maken een phonebook waarbij we ook de gemeente kunnen toevoegen, dit zal beste werken als we dictionary in dictionary steken
            Dictionary<string, Dictionary<string, string>> phoneBook = new Dictionary<string, Dictionary <string, string> >();
            bool activeUser = true;
           
            do
            {
                Console.Clear();
                Console.WriteLine("Wil je (nog) een city, naam en nummer inlezen");
                Console.Write("> ");
                string awnser = Console.ReadLine();

                switch (awnser)
                {
                    case "ja":
                    case "Ja":
                    case "JA":
                    case "jA":
                        Console.Write("Gemeente > ");
                        string city = Console.ReadLine();
                        //als gemeente nog niet toegevoegd is zullen ze deze entrie toevoegen
                        if (!phoneBook.TryGetValue(city, out var cityOut))
                        {
                            phoneBook.Add(city, new Dictionary<string, string>());
                        }
                        Console.Write("Naam > ");
                        string name = Console.ReadLine();
                        Console.Write("Nummer > ");
                        string number = Console.ReadLine();

                        //voor de name en number gaan we de value van city gebruiken die  zich linkt aan de key van de andere dictionary 
                        phoneBook[city][name] = number;

                        
                        break;

                    default:
                        activeUser = false;
                        break;
                }

            } while (activeUser);
            ViewPhoneBookCityNameNumber(phoneBook);
            Console.Write("> ");
            Console.ReadKey();
        }

        private static void ViewPhoneNameNumber(Dictionary<string, string> phonebook)
        {
            foreach (KeyValuePair<string, string> data in phonebook)
            {
                Console.WriteLine($"{data.Key}: {data.Value}");
            }
        }
        private static void ViewPhoneBookCityNameNumber(Dictionary<string, Dictionary<string, string>> phonebook)
        {
            foreach (var city in phonebook)
            {
                string cityEntry = city.Key;

                Console.WriteLine($"Gemeente: {cityEntry}");
                foreach(var person in city.Value)
                {
                    Console.WriteLine($"- {person.Key}: {person.Value}");
                }
            }
        }
    }
}