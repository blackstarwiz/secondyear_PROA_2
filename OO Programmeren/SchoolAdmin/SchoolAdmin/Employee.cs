using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal abstract class Employee : Person
    {
        //private static ImmutableList<Employee> allEmployees = ImmutableList<Employee>.Empty;
        private byte seniority;

        private ImmutableDictionary<string, byte> tasks = ImmutableDictionary<string, byte>.Empty;

        public Employee(string name, DateTime birthdate, Dictionary<string, byte> inputtask) : base(name, birthdate)
        {
            //allEmployees = allEmployees.Add(this);

            if (inputtask != null)
            {
                foreach (var task in inputtask)
                {
                    tasks = tasks.Add(task.Key, task.Value);
                }
            }
        }

        //lijst van administratief mederwerkers
        public Employee AllEmployees
        {
            get
            {
                return this;
            }
        }

        //tijd in dienst
        public byte Seniority
        {
            get
            {
                return seniority;
            }
            set
            {
                if (value > 50)
                {
                    seniority = 50;
                }
                else
                {
                    seniority = value;
                }
            }
        }

        public ImmutableDictionary<string, byte> Tasks
        {
            get
            {
                return tasks;
            }
        }

        public abstract uint CalculateSalary();

        public override string GenerateNameCard()
        {
            return "";
        }

        public override double DetermineWorkload()
        {
            return 0.0;
        }
    }
}