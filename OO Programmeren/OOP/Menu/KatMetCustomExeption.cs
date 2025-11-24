namespace Menu
{
    internal class KatMetCustomExeption
    {
        private int leeftijd;
        private int laagst;
        private int hoogst;

        public KatMetCustomExeption(int laagste = 0, int hoogste = 0)

        {
            this.laagst = laagste;
            this.hoogst = hoogste;
        }

        public int Leeftijd
        {
            get
            {
                return leeftijd;
            }
            set
            {
                if (value < laagst || value > hoogst)
                    throw new KatLeeftijdException(value, laagst, hoogst);

                leeftijd = value;
            }
        }

        public static void DemonstreerLeeftijdKatMetCustomException()
        {
            List<KatMetCustomExeption> katten = new List<KatMetCustomExeption>();
            Random rn = new Random();

            try
            {
                for(int i = 0; i < 20; i++)
                {
                    int leeftijd = rn.Next(0, 31);
                    var kat = new KatMetCustomExeption(0, 25);

                    kat.Leeftijd = leeftijd;

                    katten.Add(kat);
                }
               
                Console.WriteLine("De volledige lijst met katten is aangemaakt");
            }catch(KatLeeftijdException k)
            {
                Console.WriteLine(k.Message);
                Console.WriteLine($"MeegegevenWaarde = {k.MeegegevenWaarde},  geldige range =  {k.LaagstMogelijkeWaarde}-{k.HoostMogelijkeWaarde}");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                katten.Clear();
            }
        }
    }
}