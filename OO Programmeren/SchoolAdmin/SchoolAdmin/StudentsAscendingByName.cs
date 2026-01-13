using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudentsAscendingByName: IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            //
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1; //A tot
            if (y == null)//Z
                return 1;

            return x.Name.CompareTo(y.Name);
        }
    }
}
