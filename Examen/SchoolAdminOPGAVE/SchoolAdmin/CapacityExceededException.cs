using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class CapacityExceededException : ApplicationException
    {
        public CapacityExceededException(string message) : base(message)
        { }
    }
}
