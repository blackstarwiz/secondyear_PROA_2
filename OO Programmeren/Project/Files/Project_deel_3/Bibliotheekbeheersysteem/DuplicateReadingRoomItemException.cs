using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheekbeheersysteem
{
    internal class DuplicateReadingRoomItemException: Exception
    {
        private Object object1;
        private Object object2;

        public DuplicateReadingRoomItemException(string msg, Object nieuwe, Object bestaande) : base(msg)
        {
            object1 = nieuwe;
            object2 = bestaande;
        }

        public Object Object1
        {
            get
            {
                return object1;
            }
        }

        public Object Object2
        {
            get
            {
                return object2;
            }
        }
    }
}
