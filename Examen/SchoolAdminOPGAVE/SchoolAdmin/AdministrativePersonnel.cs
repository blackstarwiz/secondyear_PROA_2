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
        private Dictionary<DateTime, string> facilityRequests = new Dictionary<DateTime, string>();
        public Dictionary<DateTime, string> FacilityRequests
        {
            get { return facilityRequests; }
        }

        public static ImmutableList<AdministrativePersonnel> AllAdministrativePersonnel
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<AdministrativePersonnel>();
                foreach (Person pers in Person.AllPersons)
                {
                    if (pers is AdministrativePersonnel)
                    {
                        builder.Add((AdministrativePersonnel)pers);
                    }
                }

                return builder.ToImmutableList<AdministrativePersonnel>();
            }
        }
        public AdministrativePersonnel(string name, DateTime birthDate, Dictionary<string, byte> tasks) : base(name, birthDate, tasks)
        {
        }
        public override double DetermineWorkload()
        {
            double total = 0;
            foreach (var taak in Tasks)
            {
                total += taak.Value;
            }
            return total;
        }
        public override uint CalculateSalary()
        {
            double baseSalary = 2000 + (Seniority / 3 * 75);
            double fraction = DetermineWorkload() / 40;
            return (uint)(baseSalary * fraction);
        }
        public override string GenerateNameCard()
        {
            return $"{this.Name} (ADMINISTRATIE)";
        }

        public override string ToString()
        {
            return base.ToString() + "\nAdministratief personeel";

        }
        public override string ToCSV()
        {
            return "Administratief personeel;" + base.ToCSV();
        }
    }
}
