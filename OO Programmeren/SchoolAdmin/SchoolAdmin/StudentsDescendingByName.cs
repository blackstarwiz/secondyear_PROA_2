using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudentsDescendingByName : IComparer<Student>
    {
        //We gaan ICompare implementeren en zeggen hoe we gaan sorteren
        public int Compare(Student? x, Student? y)
        {
            //1. Als de namen gelijk zijn aan elkaar sturen we 0
            if (x == null && y == null)
                return 0;
            if (y == null)
                //2. Als student object y voor x gaat
                return -1; //Z tot
            // 3. Als student object x voor y gaat
            if (x == null)//A
                return 1;

            //We gebruiken hiervoor de naam van elk student object
            if (y.Name is null)
                return 0;

            return y.Name.CompareTo(x.Name);
        }
    }
}
