using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        public string Naam;
        public DateTime GeboorteDatum;
        public uint StudentenNummer;
        public string[] Cursussen;
        public static uint StudentenTeller = 0;


        public string toonInfo()
        {
            string studentInfo = $"{Naam}{GeboorteDatum}{Cursussen}{StudentenNummer}";
            return studentInfo;
        }
    }
}
