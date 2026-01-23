using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public enum ClassGroup
    {
        A = 1,B,C
    }
    public class ClassGroupPicker : IClassGroupPicker
    {
        private static Random random = new Random();

        public ClassGroup PickClass()
        {
            return (ClassGroup)random.Next(1, 4);
        }
    }
}
