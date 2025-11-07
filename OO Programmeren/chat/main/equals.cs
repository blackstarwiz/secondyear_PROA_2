using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    internal class equals
    {
        private string? input;

        public string? Input
        {
            get
            {
                return input;
            }
            set
            {
                if (value is null)
                    throw new ArgumentException("geen input te zien");
                input = value;
            }
        }

        object a = new object();
        object b = new object();
        

        public void TaskOne()
        {
            var check = a.Equals(b);

            Input = check.ToString();
        }

        public override string? ToString()
        {
            return Input;
        }

        
    }

    public class person
    {

    }
}
