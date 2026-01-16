using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class CoursesSortByCreditPoints : IComparer<Course>
    {

        public int Compare(Course? x, Course? y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            return x.CreditPoints.CompareTo(y.CreditPoints);
        }
    }
}
