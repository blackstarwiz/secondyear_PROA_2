using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExercises
{
    internal class DataStructures
    {
        static public void ShowSubmenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Uit te voeren oefening?");
                Console.WriteLine("1. H13-PhoneBookNameNumber");
                Console.WriteLine("2. H13-PhoneBookCityNameNumber");
                Console.WriteLine("3. H13-PhoneBookWithBuilder");
               // Console.WriteLine("4. Aankoop product");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PhoneBookNameNumber();
                        break;
                    case 2:
                        PhoneBookCityNameNumber();
                        break;
                    case 3:
                        PhoneBookWithBuilder();
                        break;
                    case 4:
                        //   FoodPurchase.DemoPurchase();
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze!");
                        break;
                }
            }
        }
        public static void PhoneBookNameNumber()
        {
            var phoneBook = new Dictionary<string, string>();

            Console.WriteLine("Wil je een naam en nummer inlezen?");
            string goOn = Console.ReadLine();
            while (goOn.ToLower() == "ja")
            {
                Console.WriteLine("Naam?");
                string name = Console.ReadLine();
                Console.WriteLine("Nummer?");
                string number = Console.ReadLine();
                phoneBook[name] = number;
                Console.WriteLine("Wil je (nog) een naam en nummer inlezen?");
                goOn = Console.ReadLine();
            }

            foreach (var nameNumber in phoneBook)
            {
                Console.WriteLine($"{nameNumber.Key}: {nameNumber.Value}");
            }
        }
        public static void PhoneBookCityNameNumber()
        {

            var phoneBook = new Dictionary<string, Dictionary<string, string>>();
            Console.WriteLine("Wil je een gemeente, naam en nummer inlezen?");
            string goOn = Console.ReadLine();

            while (goOn.ToLower() == "ja")
            {
                Console.WriteLine("Gemeente?");
                string city = Console.ReadLine();
                if (!phoneBook.ContainsKey(city))
                {
                    phoneBook.Add(city, new Dictionary<string, string>());
                }
                Console.WriteLine("Naam?");
                string name = Console.ReadLine();
                Console.WriteLine("Nummer?");
                string number = Console.ReadLine();
                phoneBook[city][name] = number;
                Console.WriteLine("Wil je nog een gemeente, naam en nummer inlezen?");
                goOn = Console.ReadLine();
            }
            foreach (var city in phoneBook)
            {
                Console.WriteLine($"Gemeente: {city.Key}");
                foreach (var nameNumber in city.Value)
                {
                    Console.WriteLine($"{nameNumber.Key}: {nameNumber.Value}");
                }
            }

        }
        public static void PhoneBookWithBuilder()
        {
            string goOn;
            var builder = ImmutableDictionary.CreateBuilder<string, string>();
            do
            {
                Console.WriteLine("Wil je (nog) een naam en nummer inlezen?");
                goOn = Console.ReadLine();
                if (goOn.ToLower() == "ja")
                {
                    Console.WriteLine("Naam?");
                    string name = Console.ReadLine();
                    Console.WriteLine("Nummer?");
                    string number = Console.ReadLine();
                    builder[name] = number;
                }
            } while (goOn.ToLower() == "ja");
            var phoneBook = builder.ToImmutableDictionary<string, string>();
            foreach (var nameNumber in phoneBook)
            {
                Console.WriteLine($"{nameNumber.Key}: {nameNumber.Value}");
            }
        }

    }
}3
