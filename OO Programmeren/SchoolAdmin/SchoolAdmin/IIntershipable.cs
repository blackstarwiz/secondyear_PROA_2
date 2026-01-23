using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal interface IIntershipable
    {
        TimeSpan Hours { get; }
        string Company { get; set; }

        void PrintIntershipInfo() { }
    }
}
