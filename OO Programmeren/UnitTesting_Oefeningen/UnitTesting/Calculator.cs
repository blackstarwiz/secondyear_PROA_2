using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public enum BMICategory
    {
        UnderWeight = 16,
        HealthyWeight = 23,
        OverWeight = 32
    }
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }


        public  bool Even(int a)
        {
            //Het getal is even als het deel baar is door twee en er blijdt 0 resten over

            //Hiervoor gaan we modulu gebruiken
            if (a % 2 == 0)
                return true;
            return false;
        }

        public bool Odd(int a)
        {
            if (a % 2 == 0)
                return false;
            return true;
        }

        public double BMICalculator(double gewicht, double lengte)
        {
            double lengtToPow2 = Math.Pow(lengte, 2);

            return Math.Round(gewicht / lengtToPow2); ;
        }

        public BMICategory BMIRange(double bmi)
        {
            if (bmi < 0)
                throw new ArgumentNullException("Geen geldige BMI");

            if (bmi <= ((double)BMICategory.UnderWeight)) return BMICategory.UnderWeight;
            if (bmi <= ((double)BMICategory.HealthyWeight)) return BMICategory.HealthyWeight;
            if (bmi <= ((double)BMICategory.OverWeight)) return BMICategory.OverWeight;

            return BMICategory.OverWeight;
        }
    }
}
