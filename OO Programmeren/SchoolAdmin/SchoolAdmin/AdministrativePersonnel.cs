using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class AdministrativePersonnel : Employee
    {
        public AdministrativePersonnel(string name, DateTime birthdate, Dictionary<string, byte> task) : base(name, birthdate, task)
        {
            
        }

        public AdministrativePersonnel AllAdministrativePersonnel
        {
            get
            {
                return this;
            }
        }

        public override string ToString()
        {
            string person = "Person\n";
            string underline = $"{String.Empty.PadRight(person.Length, '-')}\n";
            string name = $"Name: {GenerateNameCard()}\n";
            string age = $"Leeftijd: {Age}\n";
            string admin = $"Administratief personeel";

            return $"{person}{underline}{name}{age}{admin}";
        }

        public override uint CalculateSalary()
        {
            uint basisSalary = 2000;
            uint resultSalary = 0;

            if (this.Seniority >= 3)
            {
                //jaren dienst ==> decimal years
                var y = this.Seniority / 3;
                decimal years = Math.Floor(Convert.ToDecimal(y));

                //werkbelasting ophalen van werknemen
                double workload = this.DetermineWorkload();

                //basis + accientiteit x workload / voltijdswerk(40u);
                resultSalary = Convert.ToUInt32((basisSalary + Convert.ToUInt32((years * 75))) * workload / 40);
            }
            else
            {
                resultSalary = basisSalary;
            }

            return resultSalary;
        }

        public override double DetermineWorkload()
        {
            return this.Tasks.Values.Sum(v => (double)v);
        }

        public override string GenerateNameCard()
        {
            return $"{this.Name} (ADMINISTRATIE)";
        }
    }
}