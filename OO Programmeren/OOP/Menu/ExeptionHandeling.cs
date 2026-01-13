using System.Security.AccessControl;

namespace Menu
{
    internal class ExeptionHandeling : Exception
    {
        private bool active = true;
        private string[] exeptionHandelingMenu = ["h16-weekdagen-zonder-exception-handling", "h16-weekdagen-met-exception-handling", "h16-overflow-zonder-exception-handling", "h16-overflow-met-exception-handling", "h16-juiste-index", "h16-juiste-index-exeption", "h16-leeftijd-kat", "h16-leeftijd-katten", "h16-filehelper", "h16-leeftijd-kat-custom", "h16-gedeeltelijke-afhandeling", "Terug naar hoofdmenu"];

        public static void ShowSubMenu()
        {
            ExeptionHandeling menu = new ExeptionHandeling();
            do
            {
                Console.Clear();
                for (int i = 0; i < menu.exeptionHandelingMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{menu.exeptionHandelingMenu[i]}");
                }
                Console.Write("> ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        DemonstreerFoutafhandelingWeekdagenZonderException();
                        break;

                    case 2:

                        DemonstreerFoutafhandelingWeekdagenMetException();

                        break;

                    case 3:
                        DemonstreerFoutafhandelingOverflowZonderException();
                        break;

                    case 4:
                        DemonstreerFoutAfhandelingOverflowMetException();
                        break;

                    case 5:
                        DemonstreerKeuzeElement();
                        break;

                    case 6:
                        DemonstreerKeuzeElementExeption();
                        break;

                    case 7:
                        try
                        {
                            Kat kat = new Kat(27);
                        }
                        catch (ArgumentException a)
                        {
                            Console.WriteLine(a.Message);
                        }
                        break;

                    case 8:
                        Kat.DemonstreerLeeftijdKatMetResourceCleanup();
                        break;

                    case 9:
                        FileHelper();
                        break;

                    case 10:
                        KatMetCustomExeption.DemonstreerLeeftijdKatMetCustomException();

                        break;

                    case 11:
                        DateTime day1 = DateTime.Now;
                        DateTime day2 = DateTime.Now.AddDays(4);

                        TimeSpan aantaldag = day2 - day1;
                        DemonstreerFormulieren();
                        break;

                    default:
                        if (choice == menu.exeptionHandelingMenu.Length)
                        {
                            menu.active = false;
                        }
                        else
                        {
                            Console.WriteLine("Ingevoerde keuze staat niet in de lijst, Klik op Enter");
                            Console.ReadKey();
                        }

                        break;
                }
                if (choice <= menu.exeptionHandelingMenu.Length - 1)
                {
                    Console.WriteLine("Druk op enter om terug naar Exeption menu te gaan");
                    Console.Write("> ");
                    Console.ReadKey();
                }
            } while (menu.active);
        }

        private static void DemonstreerFoutafhandelingWeekdagenZonderException()
        {
            string[] arr = new string[5];
            arr[0] = "Vrijdag";
            arr[1] = "Maandag";
            arr[2] = "Dinsdag";
            arr[3] = "Woensdag";
            arr[4] = "Donderdag";

            for (int i = 0; i <= arr.Length; i++)
            {
                Console.WriteLine(arr[i].ToString());
            }
        }

        private static void DemonstreerFoutafhandelingWeekdagenMetException()
        {
            string[] arr = new string[5];
            arr[0] = "Vrijdag";
            arr[1] = "Maandag";
            arr[2] = "Dinsdag";
            arr[3] = "Woensdag";
            arr[4] = "Donderdag";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(arr[i].ToString());
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Dit is wat te ver");
            }
        }

        private static void DemonstreerFoutafhandelingOverflowZonderException()
        {
            int num1, num2, calulated;
            byte resultaat;
            num1 = 30;
            num2 = 60;
            calulated = num1 * num2;
            if (calulated > 255)
            {
                Console.WriteLine("{0} x {1} = {2}", num1, num2, calulated);
            }
            else
            {
                resultaat = Convert.ToByte(calulated);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, resultaat);
            }
        }

        private static void DemonstreerFoutAfhandelingOverflowMetException()
        {
            int num1, num2, calulated;
            byte resultaat;
            num1 = 30;
            num2 = 60;
            calulated = num1 * num2;

            try
            {
                resultaat = Convert.ToByte(calulated);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, resultaat);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("berekening is groter de byte (0-255)");
                Console.WriteLine("{0} x {1} = {2}", num1, num2, calulated);
            }
        }

        private static void DemonstreerKeuzeElement()
        {
            bool active = true;
            int result = 0;
            string geefIndex = "Geef index van het getal in dat je wil zien";
            string keuzeIndex = "Het getal is ";
            string doorGaan = "Wil je doorgaan";

            string hebbenWeNiet = "Die index hebben we niet!";

            string inputIndex = "";
            //string inputDoorGaan = "";

            Random rn = new Random();
            int[] array = new int[3];

            for (int i = 0; i < array.Length; i++)
            {
                int x = rn.Next(0, 101);
                array[i] = x;
            }

            do
            {
                Console.Clear();
                Console.WriteLine(geefIndex);
                inputIndex = Console.ReadLine() ?? "";

                result = Convert.ToInt32(inputIndex);

                if (result < 0)
                {
                    Console.WriteLine(hebbenWeNiet);
                }
                else if (result > array.Length)
                {
                    Console.WriteLine(hebbenWeNiet);
                }
                else
                {
                    Console.WriteLine($"{keuzeIndex}{array[result]}");
                }

                Console.WriteLine(doorGaan);
                string awnser = Console.ReadLine() ?? "";

                if (awnser == "nee")
                    active = false;
            } while (active);
        }

        private static void DemonstreerKeuzeElementExeption()
        {
            bool active = true;
            int result = 0;
            string geefIndex = "Geef index van het getal in dat je wil zien";
            string keuzeIndex = "Het getal is ";
            string doorGaan = "Wil je doorgaan";

            string hebbenWeNiet = "Die index hebben we niet!";

            string inputIndex = "";
            //string inputDoorGaan = "";

            Random rn = new Random();
            int[] array = new int[3];

            for (int i = 0; i < array.Length; i++)
            {
                int x = rn.Next(0, 101);
                array[i] = x;
            }

            do
            {
                Console.Clear();
                Console.WriteLine(geefIndex);
                inputIndex = Console.ReadLine() ?? "";

                try
                {
                    result = Convert.ToInt32(inputIndex);
                }
                catch (FormatException f)
                {
                    Console.WriteLine($"Format is niet juist {inputIndex} verwachte format (1,100,1000,...)");
                    break;
                }
                catch (OverflowException o)
                {
                    Console.WriteLine("Input is te groot!");
                    break;
                }

                if (result < 0)
                {
                    Console.WriteLine(hebbenWeNiet);
                }
                else if (result > array.Length)
                {
                    Console.WriteLine(hebbenWeNiet);
                }
                else
                {
                    Console.WriteLine($"{keuzeIndex}{array[result]}");
                }

                Console.WriteLine(doorGaan);
                string awnser = Console.ReadLine() ?? "";

                if (awnser == "nee")
                    active = false;
            } while (active);
        }

        private static void FileHelper()
        {
            Console.WriteLine("Welke file wil je lezen?");
            Console.Write("> ");

            string filePath = Console.ReadLine() ?? "";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (FileNotFoundException n)
            {
                Console.WriteLine("File kon niet gevonden worden.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("File bestaat, maar kon niet gelezen worden. Mogelijk heb je geen toegangsrechten.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("File kon niet gevonden worden.");
            }
            catch (Exception)
            {
                Console.WriteLine("Er is iets misgelopen. Neem een screenshot van wat je aan het doen was contacteer de helpdesk.");
            }
        }

        private static void DemonstreerFormulieren()
        {
            var vraag1 = new FormulierGetalVraag("Hoe oud ben je?", 18, 130);
            var vraag2 = new FormulierVrijeTekstVraag("Hoe ziet jouw ideale dag eruit?");
            var vraag3 = new FormulierGetalVraag("Hoe veel personen heb je ten laste?", 0, 10);
            var vraag4 = new FormulierVrijeTekstVraag("Wie is je idool?");
            Formulier f1 = new Formulier(new List<FormulierVraag> { vraag1, vraag2 });
            Formulier f2 = new Formulier(new List<FormulierVraag> { vraag3, vraag4 });
            try
            {
                f1.VulIn();
                f1.Toon();
            }
            catch (Exception)
            {
                System.Console.WriteLine("We zullen dit formulier weggooien.");
                f1 = new Formulier(); ;
            }
            try
            {
                f2.VulIn();
                f2.Toon();
            }
            catch (Exception)
            {
                System.Console.WriteLine("We zullen dit formulier weggooien.");
                f2 = new Formulier();
            }
        }
    }
}