using System.Collections.Immutable;

namespace Menu
{
    internal class Datastructuren
    {
        private bool active = true;
        private string[] dataStructureMenu = ["H13-PhoneBookNameNumber", "H13-PhoneBookCityNameNumber", "Terug naar Hoofdmenu"];

        public static void ShowSubMenu()
        {
            Datastructuren menu = new Datastructuren();
            do
            {
                Console.Clear();
                for (int i = 0; i < menu.dataStructureMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{menu.dataStructureMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        PhoneBookNameNumber();
                        break;

                    case 2:
                        PhoneBookCityNameNumber();

                        break;

                    default:
                        menu.active = false;
                        break;
                }
                if (choice <= menu.dataStructureMenu.Length - 1)
                    Console.ReadKey();
            } while (menu.active);
        }

        //phonebook name and number
        public static void PhoneBookNameNumber()
        {
            //we maken een key, value pair dat de naam en nummer zal bij houden
            //Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            //bool om de do-while te laten werken tot als de gebruiker nee intypte
            bool activeUser = true;

            do
            {
                Console.Clear();

                Console.Write("Naam >");
                string name = Console.ReadLine() ?? string.Empty;
                Console.Write("Nummer >");
                string number = Console.ReadLine() ?? string.Empty;

                activeUser = ViewPhoneNameNumber(ImmutableDictionaryBuilder(name, number));
            } while (activeUser);
        }

        private static ImmutableDictionary<string, string> ImmutableDictionaryBuilder(string name, string number)
        {
            var phoneBook = ImmutableDictionary.CreateBuilder<string, string>();

            //als naam al voorkomt in de phone boek vervangen we de nummer
            if (phoneBook.TryGetValue(name, out var result))
            {
                phoneBook[name] = number;
            }
            //anders voegen we de nieuwe entrie toe
            else
            {
                phoneBook.Add(name, number);
            }
            ;

            return phoneBook.ToImmutableDictionary<string, string>();
        }

        private static bool ViewPhoneNameNumber(ImmutableDictionary<string, string> phonebook)
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
                    return true;

                default:
                    foreach (KeyValuePair<string, string> data in phonebook)
                    {
                        Console.WriteLine($"{data.Key}: {data.Value}");
                    }
                    return false;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------
        //phonebook city name number
        public static void PhoneBookCityNameNumber()
        {
            bool activeUser = true;

            do
            {
                Console.Clear();
                Console.Write("gemeente >");
                string city = Console.ReadLine() ?? string.Empty;
                Console.Write("Naam >");
                string name = Console.ReadLine() ?? string.Empty;
                Console.Write("Nummer >");
                string number = Console.ReadLine() ?? string.Empty;

                activeUser = ViewPhoneBookCityNameNumber(ImmutableMultiDictionaryBuilder(city, name, number));
            } while (activeUser);
        }

        private static ImmutableDictionary<string, ImmutableDictionary<string, string>> ImmutableMultiDictionaryBuilder(string city, string name, string number)
        {
            var phoneBook = ImmutableDictionary.CreateBuilder<string, ImmutableDictionary<string, string>>();

            if (phoneBook.TryGetValue(city, out var cityBook))
            {
                phoneBook[city] = cityBook.Add(name, number);
            }
            else
            {
                //als deze al bestaat gaan we name, number toevoegen aan de phoneBook[key] --> welke gemeente
                //dit doen we zoals we de 'grotere' dict willen maken maar dan waar de city moet zijn deze is leeg om dat die er al is
                //met dit kunnen we een Add(K,V) gebruiken waar de waardes horen,
                phoneBook[city] = ImmutableDictionary<string, string>.Empty.Add(name, number);
            }

            return phoneBook.ToImmutableDictionary();
        }

        private static bool ViewPhoneBookCityNameNumber(ImmutableDictionary<string, ImmutableDictionary<string, string>> phonebook)
        {
            Console.Clear();
            Console.WriteLine("Wil je (nog) een gemeente,naam en nummer inlezen");
            Console.Write("> ");

            string awnser = Console.ReadLine();
            switch (awnser)
            {
                case "ja":
                case "Ja":
                case "JA":
                case "jA":
                    return true;

                default:
                    foreach (var city in phonebook)
                    {
                        string cityEntry = city.Key;

                        Console.WriteLine($"Gemeente: {cityEntry}");
                        foreach (var person in city.Value)
                        {
                            Console.WriteLine($"- {person.Key}: {person.Value}");
                        }
                    }
                    return false;
            }
        }
    }
}