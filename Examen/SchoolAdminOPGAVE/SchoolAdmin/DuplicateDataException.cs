using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class DuplicateDataException : ApplicationException
    {
        private object object1;
        public object Object1
        {
            get { return object1; }
            private set { object1 = value; }
        }

        private object object2;
        public object Object2
        {
            get { return object2; }
            private set { object2 = value; }
        }

        public DuplicateDataException(string message, object o1, object o2) : base(message)
        {
            this.Object1 = o1;
            this.Object2 = o2;
        }
    }
}
