using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Triangle
    {
        private double @base;
        private double height;
        private double area;


        public Triangle(double baseTri, double height)
        {
            this.Base = baseTri;
            this.Height = height;
        }


        public double Base
        {
            get
            {
                return @base;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw new Exception($"Het is verboden een Basis van {value} in te stellen!");
                }
                @base = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw new Exception($"Het is verboden een Hoogte van {value} in te stellen!");
                }
                height = value;
            }
        }

        public double Area
        {
            get
            {
                return Math.Round(Base * Height / 2);
            }
        }
    }
}
