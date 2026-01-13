using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }


        public bool Even(int a)
        {
            if (a % 2 == 0)
                return true;
            return false;
        }


        public double BMI(double gewicht, double lengte)
        {
            double lengtToPow2 = Math.Pow(lengte, 2);

            return Math.Round(gewicht / lengtToPow2);
        }

    }
}
