using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Kat
    {
        private int leeftijd;

        public Kat(int leeftijd)
        {
            if (leeftijd > 25)
                throw new ArgumentException("Deze kat is te oud!");
            this.leeftijd = leeftijd;
        }

        public int Leeftijd
        {
            get
            {
                return leeftijd;
            }
        }

        public static void DemonstreerLeeftijdKatMetResourceCleanup()
        {
            List<Kat> katten = new List<Kat>();
            Random rn = new Random();

            try
            {
                for (int i = 0; i < 20; i++)
                {
                    int leeftijd = rn.Next(0, 31);
                    Kat nieuwekat = new Kat(leeftijd);
                    katten.Add(nieuwekat);
                }

                Console.WriteLine("De volledige lijst met katten is aangemaakt");
            }catch(ArgumentException a)
            {
                Console.WriteLine("Het is niet geluk :-(");

            }catch(Exception e)
            {
                Console.WriteLine("Het is niet gelukt :-(");
            }
            finally
            {
                katten.Clear();
            }
            
        }
    }
}