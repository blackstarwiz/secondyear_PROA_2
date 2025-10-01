using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Rectangle
    {
        private double width;
        private double height;


        public Rectangle(double width,double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if(value <= 0.0)
                {
                    throw new Exception($"Het is verboden een Breedte van {value} in te stellen!");
                }

                width = value;
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
                return Math.Round(Width * Height);
            }
        }
    }
}
