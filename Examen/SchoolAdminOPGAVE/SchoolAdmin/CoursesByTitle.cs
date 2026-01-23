using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class CoursesByTitle: IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            if (x is null)
            {
                return -1;
            }
            else if (y is null)
            {
                return 1;
            }
            else
            {
                return x.Title.CompareTo(y.Title);
            }
        }
    }
}
