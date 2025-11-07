using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Order
    {
        //property
        private uint number;
        //atribute
        protected double unitPrice;
        //computed property
        public virtual double TotalPrice => Number * unitPrice;

        //constructor
        public Order(uint number,double unitPrice)
        {
            Number = number;
            this.unitPrice = unitPrice;
        }


        //property
        public uint Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
    }
}
