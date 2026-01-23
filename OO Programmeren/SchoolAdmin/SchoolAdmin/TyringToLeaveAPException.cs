using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class TyringToLeaveAPException: Exception
    {
        private string name;

        public TyringToLeaveAPException(string name) : base(name)
        {
            this.name = name;
        }
    }
}
