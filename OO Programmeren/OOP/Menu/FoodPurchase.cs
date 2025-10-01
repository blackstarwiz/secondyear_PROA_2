using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class FoodPurchase
    {
        private bool refrigerate;
        private string procductName;
        private int number;
        private double unitPrice;
        private DateTime expirationDate;

        public FoodPurchase(string ProductName, byte Number, double Unitprice, bool Refrigerate)
        {
            this.procductName = ProductName;
            this.Number = Number;
            this.UnitPrice = Unitprice;
            this.Refrigerate = Refrigerate;
            this.ExpirationDate = DateTime.Now.AddMonths(2);
        }

        public bool Refrigerate
        {
            get
            {
                return refrigerate;
            }
            set
            {
                refrigerate = value;
            }
        }

        public string ProductName
        {
            get
            {
                return procductName;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Ongeldig aantal");
                }
                number = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value < 0 | value > 5000)
                {
                    throw new Exception("Ongeldige eenheidsprijs");
                }
                unitPrice = value;
            }
        }

        public DateTime ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value;
            }
        }

        public static void DemoPurchase()
        {
            double total;
            FoodPurchase buy1 = new FoodPurchase("cheese", 2, 2.45, true);

            total = buy1.Number * buy1.UnitPrice;
            Console.WriteLine($"De totaalprijs van {buy1.ProductName} is {total}\nDe vervaldatum van aankoop 1 is {buy1.ExpirationDate}");

            FoodPurchase buy2 = new FoodPurchase("butter", 0, 5555, true);

            total = buy2.Number * buy2.UnitPrice;
            Console.WriteLine($"De totaalprijs van {buy2.ProductName} is {total}\nDe vervaldatum van aankoop 1 is {buy2.ExpirationDate}");
        }
    }
}