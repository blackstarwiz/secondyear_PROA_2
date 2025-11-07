using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    internal abstract class Employee:Person
    {
        private byte seniority;
        public byte Seniority
        {
            get { return seniority; }
            set { this.seniority = Math.Min((byte)50, value); }
        }
        private Dictionary<string, byte> tasks = new Dictionary<string, byte>();
        public ImmutableDictionary<string, byte> Tasks
        {
            get { return tasks.ToImmutableDictionary<string, byte>(); }
        }
        private static List<Employee> allEmployees = new List<Employee>();
        public static ImmutableList<Employee> AllEmployees
        {
            get
            {
                return allEmployees.ToImmutableList<Employee>();
            }
        }
        public Employee(string name, DateTime birthDate, Dictionary<string, byte> tasks) : base(name, birthDate)
        {
            if (!(tasks is null))
            {
                foreach (var item in tasks) 
                {
                    this.tasks.Add(item.Key, item.Value);
                }
            }
            allEmployees.Add(this);
        }

        public abstract uint CalculateSalary();
    }
}
