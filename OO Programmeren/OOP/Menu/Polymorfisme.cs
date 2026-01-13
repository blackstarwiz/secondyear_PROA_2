using System.Collections.Immutable;
using System.Globalization;

namespace Menu
{
    internal class Polymorfisme
    {
        private bool active = true;
        private string[] polymorfismeMenu = ["h17-autoconstructeur", "h17-grootkeuken", "h17-Rooster(Stap1)", "h17-Rooster(Stap2)", "h17-Rooster(Stap3)", "Terug naar hoofdmenu"];

        public static void ShowSubMenu()
        {
            Polymorfisme menu = new();
            do
            {
                Console.Clear();

                for (int i = 0; i < menu.polymorfismeMenu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {menu.polymorfismeMenu[i]}");
                }
                Console.Write("> ");
                string choice = Console.ReadLine() ?? "";

                try
                {
                    if (!int.TryParse(choice, out int res))
                    {
                        if (choice == "")
                            throw new ArgumentException("Kies een optie");
                        throw new FormatException("Ingevoerde waarde is een tekst");
                    }
                    else
                    {
                        if (res > menu.polymorfismeMenu.Length)
                        {
                            throw new IndexOutOfRangeException("Igevoerde keuze staat niet in de lijst");
                        }
                    }

                    switch (res)
                    {
                        case 1:
                            DemonstreerAandrijving();
                            Console.Write("Druk op Enter >");
                            Console.ReadKey();
                            break;

                        case 2:
                            DemonstreerGrootkeuken();
                            Console.Write("Druk op Enter >");
                            Console.ReadKey();
                            break;
                        case 3:
                            DemonstreerIRoosterbaar();
                            Console.Write("Druk op Enter >");
                            Console.ReadKey();
                            break;
                        case 4:
                            DemonstreerKalender1();
                            Console.Write("Druk op Enter >");
                            Console.ReadKey();
                            break;
                        case 5:
                            DemonstreerKalender2();
                            Console.Write("Druk op Enter >");
                            Console.ReadKey();
                            break;

                        default:

                            menu.active = false;

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Druk op Enter > ");
                    Console.ReadKey();
                }
            } while (menu.active);
        }

        private static void DemonstreerAandrijving()
        {
            Console.Clear();
            Auto mijnauto = new Auto("Tesla", new AandrijvingElekrisch());//poly

            mijnauto.ToonHuidigeAandrijving();//aangemaakte aandrijving
            mijnauto.Aandrijving.Versnellen(10, 100);//we gaan langs klasse auto om de versnelling van het object te gebruiken van de interface IAandrijving
            mijnauto.Aandrijving.EnergieToevoegen();//dit doen we ook voor EnergieToevoegen
            Console.WriteLine();

            //aanpassen van aandrijving
            mijnauto = new Auto("Tesla", new AandrijvingBenzine());//poly

            //alles tonen om te zien dat de aandrijving effectief verandert is
            mijnauto.ToonHuidigeAandrijving();
            mijnauto.Aandrijving.Versnellen(20, 150);
            mijnauto.Aandrijving.EnergieToevoegen();
        }

        private static void DemonstreerGrootkeuken()
        {
            List<Ketel> ketels = new();
            List<Type> ketelTypes = new List<Type> { typeof(StoomKetel), typeof(KetelZonderDoseren), typeof(KetelMetDoseren) }; //poly keuze lijst van de verschillende ketel types
            bool menu = true;
            do
            {
                try
                {
                    //Menu
                    Console.Clear();
                    Console.WriteLine("Hoeveel ketels?");
                    Console.Write("> ");
                    string aantal = Console.ReadLine() ?? "";


                    //nakijken of het een string is dat is ingevoerd Exeption handeling
                    if (!int.TryParse(aantal, out int result))
                    {
                        if (aantal == "")
                            throw new ArgumentException("Voor een geldige waarde in!");
                        throw new ArgumentException("Ingevoerde waarde is een tekst");
                    }

                    //checken of de waarde groter is dan 0
                    if (result <= 0)
                        throw new IndexOutOfRangeException("Waarde moet groter zijn dan 0");


                    //blijf herhalen tot result is bereikt
                    for (int i = 0; i < result; i++)
                    {
                        bool addKetels = true;

                        //loop zal blijven lopen tot als de huidige ketel is juist toegevoegd
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"Ketel nr-{i+1}");
                            for (int j = 0; j < ketelTypes.Count; ++j)
                            {
                                Console.WriteLine($"{j+1}: {ketelTypes[j].Name.ToString()}");
                            }
                            Console.Write("> ");
                            string type = Console.ReadLine() ?? "";

                            try
                            {
                                if (!int.TryParse(type, out int ketelResult))
                                {
                                    if (type == "")
                                        throw new ArgumentException("Kies een optie");
                                    throw new FormatException("De waarde is een ketel");
                                }
                                else
                                {
                                    if (ketelResult > ketelTypes.Count)
                                        throw new IndexOutOfRangeException("Keuze bestaat niet!");

                                    Console.WriteLine("Max inhoud in Liter vb: 1,10,100");
                                    Console.Write("> ");
                                    string input = Console.ReadLine() ?? "";

                                    if (!int.TryParse(input, out int hoeveelheid))
                                    {
                                        if (input == "")
                                            throw new ArgumentException("Voer hoeveelheid in!");
                                        throw new FormatException("Ingevoeerde waarde is een tekst");
                                    }
                                    else
                                    {
                                        Ketel ketel;//poly

                                        switch (ketelResult)
                                        {
                                            case 1://stoomketel
                                                ketel = new StoomKetel(hoeveelheid);//poly
                                                ketels.Add(ketel);
                                                Console.WriteLine("Stoom ketel klaar gepakt");
                                                addKetels = false;
                                                break;

                                            case 2://ketelzonderdosering
                                                ketel = new KetelZonderDoseren(hoeveelheid);//poly
                                                ketels.Add(ketel);
                                                Console.WriteLine("Ketel zonder doseren gepakt");
                                                addKetels = false;
                                                break;

                                            case 3://ketel met dosering
                                                ketel = new KetelMetDoseren(hoeveelheid);//poly
                                                ketels.Add(ketel);
                                                Console.WriteLine("Ketel met doseren gepakt");
                                                addKetels = false;
                                                break;
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            if (i+1 == result)
                                break;

                            Console.Write("Druk op Enter");
                            Console.ReadKey();

                        } while (addKetels);
                        menu = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.Write("Druk op Enter > ");
                Console.ReadKey();
                Console.WriteLine();
            } while (menu);



            Console.WriteLine("Ketels");

            //toon alle ketels die toegevoegd zijn aan de lijst
            foreach(var ketel in ketels)
            {
                Console.WriteLine();
                Console.WriteLine($"{ketel.GetType().Name} - {ketel.MaxInhoudInMiliter}");
            }
        }


        private static void DemonstreerIRoosterbaar()
        {
            IRoosterbaar blok1 = new Afspraak(new TimeSpan(0, 20, 0), new TimeSpan(1, 0, 0), new TimeSpan(0, 20, 0), "tandarts");
            IRoosterbaar blok2 = new Taak(new TimeSpan(2, 0, 0), "dagelijkse oefeningen OOP");
            Console.WriteLine($"Totale kalendertijd: {(blok1.TijdsDuur + blok2.TijdsDuur).Hours}u{(blok1.TijdsDuur + blok2.TijdsDuur).Minutes}m");
        }
        
        private static void DemonstreerKalender1()
        {
            Console.WriteLine("Voer naam in van kalander: ");
            Console.Write("> ");
            Kalender nieuweKalender = new Kalender(Console.ReadLine() ?? "");//aanmaken van nieuwe kalender

            nieuweKalender.Voegtoe();//Objecten toevoegen aan kalender
        }

        private static void DemonstreerKalender2()
        {
            Console.WriteLine("Voer naam in van kalander: ");
            Console.Write("> ");
            Kalender nieuweKalender = new Kalender(Console.ReadLine() ?? "");//aanmaken van nieuwe kalender

            nieuweKalender.VoegToeLosgekoppeld();//Objecten toevoegen aan kalender
            
        }

    }


}