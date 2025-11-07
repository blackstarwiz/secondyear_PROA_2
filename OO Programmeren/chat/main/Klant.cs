using System;
using System.Collections.Generic;

namespace main
{
    internal class Klant
    {
        private int klantenNummer;
        private string naam;

        public Klant(int klantenNummer,string naam)
        {
            KlantenNummer = klantenNummer;
            Naam = naam;

        }
        public int KlantenNummer
        {
            get
            {
                return klantenNummer;
            }
            set
            {
                klantenNummer = value;
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
            }
        }


        public override bool Equals(object? obj)
        {
           return obj is Klant k && KlantenNummer == k.KlantenNummer;//geeft true terug als het gelijk is anders default false
        }

        public override int GetHashCode() =>
           KlantenNummer.GetHashCode();
        
    }
}
