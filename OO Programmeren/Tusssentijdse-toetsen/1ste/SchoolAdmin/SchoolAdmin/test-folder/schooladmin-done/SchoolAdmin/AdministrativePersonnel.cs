using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class AdministrativePersonnel : Employee
    {
        private static List<AdministrativePersonnel> allAdministrativePersonnel = new List<AdministrativePersonnel>();
        public static ImmutableList<AdministrativePersonnel> AllAdministrativePersonnel
        {
            get
            {
                return allAdministrativePersonnel.ToImmutableList<AdministrativePersonnel>();
            }
        }
        public AdministrativePersonnel(string name, DateTime birthDate, Dictionary<string, byte> tasks) : base(name, birthDate, tasks)
        {
            allAdministrativePersonnel.Add(this);
        }
        public override double DetermineWorkload()
        {
            double totaal = 0;
            foreach (var taak in Tasks)
            {
                totaal += taak.Value;
            }
            return totaal;
        }
        public override uint CalculateSalary()
        {
            double basis = 2000 + (Seniority / 3 * 75);
            double breuk = DetermineWorkload() / 40;
            return (uint)(basis * breuk);
        }
        public override string GenerateNameCard()
        {
            return $"{this.Name} (ADMINISTRATIE)";
        }

        public override string ToString()
        {
            return base.ToString() + "\nAdministratief personeel";

        }
    }
}
