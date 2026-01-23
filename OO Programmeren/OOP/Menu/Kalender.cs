using System.Collections;
using System.Collections.Immutable;
using System.Globalization;

namespace Menu
{
    internal class Kalender : IEnumerable<KeyValuePair<DateTime, IRoosterbaar>> //interface
    {
        private string kalenderNaam;
        private Dictionary<DateTime, IRoosterbaar> items = new();

        //lossekoppeling
        private Dictionary<DateTime, IRoosterbaar> rooster = new();

        public Kalender(string naam)
        {
            kalenderNaam = naam;
        }
        
        public string KalenderNaam
        {
            get
            {
                return kalenderNaam;
            }
        }

        private Dictionary<DateTime, IRoosterbaar> Rooster
        {
            get { return rooster; }
        }

        public IEnumerator<KeyValuePair<DateTime, IRoosterbaar>> GetEnumerator()
        {
            // 'yield return' maakt dit veel eenvoudiger
            foreach (var item in items)
            {
                yield return item; // Retourneert elk item één voor één
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Voegtoe()
        {
            Dictionary<string, IRoosterbaar> objectenLijst = new();

            bool kalenderMenu = true; //true blijven zolang gebruiker objecten wilt toevoegen;

            do
            {
                try
                {
                    Console.Clear();

                    List<string> keuzeLijst = new List<string> { "<-- 0: Terug", new Taak().GetType().Name.ToString(), new Afspraak().GetType().Name.ToString() };
                    int counter = 0;
                    Console.WriteLine("Om wat voor object gaat het?");

                    //Keuze object (Taak, Afspraak)
                    foreach (var objects in keuzeLijst)
                    {
                        if (objects == "<-- 0: Terug")
                        {
                            Console.WriteLine($"{objects}");
                        }
                        else
                        {
                            Console.WriteLine($"{++counter} - {objects}");
                        }
                    }

                    Console.Write("Voer Optie in > ");
                    string optie = Console.ReadLine() ?? "";

                    if (!int.TryParse(optie, out int typeAfspraak))
                    {
                        if (optie == "")
                        {
                            throw new ArgumentNullException("Kies een optie;");
                        }
                        throw new FormatException("Ingevoerde optie is een tekst");
                    }

                    if (typeAfspraak > keuzeLijst.Count())
                        throw new ArgumentOutOfRangeException("Optie bestaat niet");

                    //Einde Keuze object (Taak, Afspraak)
                    //*****************************
                    //Waardes Vragen
                    IRoosterbaar objectItem = typeAfspraak switch
                    {
                        1 => TaakInput(),
                        2 => AfspraakInput(),
                        _ => throw new Exception("Terug gaan")
                    };

                    //Toevoegen van waardes
                    items.Add(Inplannen(), objectItem);

                    //Einde Waardes vragen
                    //*****************************
                    //Nog Objecten nog Toevoegen?
                    Console.WriteLine("Wil je nog een item toevoegen?");
                    Console.Write("> ");

                    string nogToevoegen = Console.ReadLine() ?? "";

                    bool nog = nogToevoegen switch
                    {
                        "ja" or
                        "jaa" or
                        "Ja" or
                        "Jaa" or
                        "JA" or
                        "JAA" => true,
                        _ => false
                    };

                    kalenderMenu = nog;
                    //Einde Objecten nog Toevoegen
                    //*****************************
                }
                catch (Exception e)
                {
                    if (e.Message == "Terug gaan")
                    {
                        Console.WriteLine(e.Message);
                        kalenderMenu = false;
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.Write("Druk op Enter > ");
                    Console.ReadKey();
                }
            } while (kalenderMenu);

            //Einde loop ShowOverView objecten

            ShowOverview();
            Console.Write("Druk op Enter > ");
            Console.ReadKey();
        }

        private IRoosterbaar TaakInput()
        {
            Console.WriteLine("Omscrijving?");
            Console.Write("> ");
            string Omschrijving = Console.ReadLine() ?? "";

            if (Omschrijving == "")
                throw new ArgumentNullException("Voer geldige waarde in");

            Console.WriteLine("Aantal minuten werken?");
            Console.Write("> ");
            string minutenWerk = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenWerk, out int minuten))
            {
                if (minutenWerk == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            if (minuten < 0)
                throw new Exception("Waarde moet positief zijn");

            Taak taak = new Taak(new TimeSpan(0, minuten, 0), Omschrijving);

            return taak;
        }

        private IRoosterbaar AfspraakInput()
        {
            Console.WriteLine("Omscrijving?");
            Console.Write("> ");
            string Omschrijving = Console.ReadLine() ?? "";

            if (Omschrijving == "")
                throw new ArgumentNullException("Voer geldige waarde in");

            Console.WriteLine("Aantal minuten heen?");
            Console.Write("> ");
            string minutenHeen = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenHeen, out int heen))
            {
                if (minutenHeen == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            Console.WriteLine("Aantal minuten afspraak zelf?");
            Console.Write("> ");
            string minutenAfspraak = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenAfspraak, out int afspraak))
            {
                if (minutenAfspraak == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            Console.WriteLine("Aantal minuten terug?");
            Console.Write("> ");
            string minutenTerug = Console.ReadLine() ?? "";

            if (!int.TryParse(minutenTerug, out int terug))
            {
                if (minutenTerug == "")
                    throw new ArgumentNullException("Voor geldige waarde in");
                throw new FormatException("Ingevoerde waarde is een string");
            }

            if (heen < 0 | afspraak < 0 | terug < 0)
                throw new Exception("Waarde moet positief zijn");

            Afspraak Afspraak = new Afspraak(new TimeSpan(0, heen, 0), new TimeSpan(0, afspraak, 0), new TimeSpan(0, terug, 0), Omschrijving);

            return Afspraak;
        }

        private static DateTime Inplannen()
        {
            Console.WriteLine("Wanneer moet dit geroosterd worden?");
            Console.Write("> ");

            string datumRooster = Console.ReadLine() ?? "";
            var culture = CultureInfo.CreateSpecificCulture("en-US");

            if (!DateTime.TryParse(datumRooster, culture, out DateTime datum))
            {
                if (datumRooster == "")
                    throw new ArgumentNullException("Voer geldige waarde in");
                throw new FormatException("Format komt niet voor. Vb:dag/maand/jaar uren:minuten AM|PM (Voor 12 middag|tot 12 s'nachts)");
            }

            return datum;
        }

        public void VoegToeLosgekoppeld()
        {
            Console.WriteLine("Om wat voor object gaat het?");
            Console.WriteLine("1. Afspraak");
            Console.WriteLine("2. Taak");
            Console.WriteLine("3. QualityTime");

            IRoosterbaar item; //poly-start
            DateTime begin;

            int antwoord = Convert.ToInt32(Console.ReadLine());

            if (antwoord == 1)

                item = new Afspraak();//poly-object
            else

                item = new Taak();//poly-object

            if (antwoord == 3)
                item = new QualityTime();

            item.Initialiseer();//losse koppeling

            begin = Inplannen();//static methode//hier vragen we wanneer het moet ingepland worden voor elke object is dit anders
            
            Rooster[item.RoosterOm(begin)] = item;//[deze datum] is gelinked aan = item (afspraak/taak)
            ShowOverview();
        }

        private void ShowOverview()
        {
            Console.WriteLine("Taken/Afspraken");
            if (items.Count == 0)
            {
                foreach (var item in this.rooster)
                {
                    Console.WriteLine($"{item.Key.ToString()} : {item.Value.Omschrijving}");
                }
            }
            else
            {
                foreach (var item in this.items)
                {
                    Console.WriteLine($"{item.Key.ToString()} : {item.Value.Omschrijving}");
                }
            }
        }
    }
}