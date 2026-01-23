using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    public abstract class Employee:Person
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

        public static ImmutableList<Employee> AllEmployees
        {
            get
            {
                var builder = ImmutableList.CreateBuilder<Employee>();
                foreach (Employee p in Employee.AllPersons)
                {
                    if (p is Employee)
                    {
                        builder.Add((Employee)p);
                    }
                }
                return builder.ToImmutableList<Employee>();
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
        }

        public abstract uint CalculateSalary();

        public override string ToCSV()
        {
            string taskInfo = "";
            foreach (var task in Tasks)
            {
                taskInfo+= $";{task.Key};{task.Value}";
            }
            return base.ToCSV() + taskInfo;
        }
    }
}
