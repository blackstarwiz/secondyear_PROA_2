using System.Globalization;
using System.Xml.Serialization;

namespace SchoolAdmin
{
    internal class Student
    {
        public string Naam;
        public DateTime GeboorteDatum;
        public uint StudentenNummer;
        private string[] cursussen;
        public uint StudentenTeller = 0;


        public string GenereerNaamKaartje()
        {
            return $"{this.Naam} (STUDENT)";
        }

        public double BepaalWerkBelasting()
        {
            return cursussen.Length * 10;
        }

        public void RegistreerVoorCursus(string cursus)
        {
           for(int i = 0; i <= cursussen.Length; i++)
            {
                cursussen[i] = cursus;
            }
        }
    }
}